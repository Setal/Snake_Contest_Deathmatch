﻿using System;
using System.Collections.Generic;
using System.Linq;
using SnakeDeathmatch.Interface;
using SnakeDeathmatch.Players.Vazba.Helper;

namespace SnakeDeathmatch.Players.Vazba.PlaygroundAnalysis
{
    public class Snakes
    {
        private IntPlayground _oldPlayground;
        private IntPlayground _newPlayground;
        private List<Snake> _others = new List<Snake>();
        public IEnumerable<Snake> Others { get { return _others; } }
        public Snake Me { get; private set; }
        public IEnumerable<Snake> OthersAndMe
        {
            get
            {
                foreach (Snake snake in _others)
                {
                    yield return snake;
                }
                yield return Me;
            }
        }

        public Snakes(Snake me)
        {
            Me = me;
        }

        public bool IsInitialized { get; private set; }

        public void Update(IntPlayground playground)
        {
            playground = playground.Clone();

            if (_oldPlayground == null && _newPlayground == null)
            {
                _oldPlayground = playground;

                for (int y = 0; y < playground.Size; y++)
                {
                    for (int x = 0; x < playground.Size; x++)
                    {
                        int playerId = playground[x, y];
                        if (playerId != 0 && playerId != Me.Id)
                            _others.Add(new Snake(playerId, x, y, null));
                    }
                }
                return;
            }

            if (_oldPlayground != null && _newPlayground == null)
            {
                _newPlayground = playground;
                IsInitialized = true;
            }
            else
            {
                _oldPlayground = _newPlayground;
                _newPlayground = playground;
            }

            var liveSnakes = new List<Snake>();

            for (int y = 0; y < _oldPlayground.Size; y++)
            {
                for (int x = 0; x < _oldPlayground.Size; x++)
                {
                    if (_oldPlayground[x, y] == 0 && _newPlayground[x, y] != 0)
                    {
                        int playerId = _newPlayground[x, y];
                        if (playerId == Me.Id)
                            Me = new Snake((int)PlayerId.Vazba, x, y, GetDirection(Me.X, Me.Y, x, y));
                        else
                        {
                            IEnumerable<Snake> snakes = Others.Where(s => s.Id == playerId);
                            if (snakes.Count() == 1)
                            {
                                Snake snake = snakes.Single();
                                liveSnakes.Add(new Snake(snake.Id, x, y, GetDirection(snake.X, snake.Y, x, y)));
                            }
                        }
                    }
                }
            }

            _others.Clear();
            _others.AddRange(liveSnakes);
        }

        private Direction GetDirection(int oldX, int oldY, int newX, int newY)
        {
            if (oldX == newX && oldY - 1 == newY) return Direction.Top;
            if (oldX == newX && oldY + 1 == newY) return Direction.Bottom;
            if (oldX + 1 == newX && oldY == newY) return Direction.Right;
            if (oldX - 1 == newX && oldY == newY) return Direction.Left;
            if (oldX + 1 == newX && oldY - 1 == newY) return Direction.TopRight;
            if (oldX - 1 == newX && oldY - 1 == newY) return Direction.TopLeft;
            if (oldX + 1 == newX && oldY + 1 == newY) return Direction.BottomRight;
            if (oldX - 1 == newX && oldY + 1 == newY) return Direction.BottomLeft;

            throw new Exception(string.Format("Old position [{0},{1}] and new position [{2},{3}] are not next to each other.", oldX, oldY, newX, newY));
        }
    }
}
