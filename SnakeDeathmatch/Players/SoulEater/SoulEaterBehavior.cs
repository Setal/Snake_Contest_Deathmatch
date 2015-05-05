﻿﻿using System;
using System.Collections.Generic;
﻿using System.Linq;
﻿using System.Security.Cryptography.X509Certificates;
﻿using System.Threading;
﻿using SnakeDeathmatch.Interface;

namespace SnakeDeathmatch.Players.SoulEater
{
    public class SoulEaterBehavior : IPlayerBehavior
    {
        #region fields and props

        private Direction _myInitialDirection;

        private int _myIdentificatior;

        private GameGround _currentGameGround;

        private readonly IList<Move> _moveList = new List<Move> { Move.Straight, Move.Left, Move.Right };

        private bool _isFirstMove = true;

        private IList<PlayerInfo> _otherPlayers = new List<PlayerInfo>();

        #endregion

        public void Init(int direction, int identificator)
        {
            _myInitialDirection = (Direction)direction;
            _myIdentificatior = identificator;
        }

        public int NextMove(int[,] gameSurrond)
        {
            if (_isFirstMove)
            {
                _currentGameGround = new GameGround(gameSurrond, _myIdentificatior, _myInitialDirection);

                _isFirstMove = false;
            }
            else
            {
                _currentGameGround.Update(gameSurrond);
            }

            Move nextMove = GetSafeMove(10);

            return (int)nextMove;
        }

        public string MyName()
        {
            return "Soul Eater";
        }

        private void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        #region move

        private Move GetSafeMove(int numberOfSafeMoves)
        {
            if (numberOfSafeMoves == 0)
                return Move.Straight;

            var copyOfGround = _currentGameGround.MakeACopy();
            copyOfGround.SimulateStateAfterOtherPlayersMove();
            copyOfGround.SimulateStateAfterOtherPlayersMove();
            copyOfGround.SimulateStateAfterOtherPlayersMove();
            copyOfGround.SimulateStateAfterOtherPlayersMove();

            foreach (Move move in _moveList)
            {
                bool isMoveSafe = GetIfMoveIsSafe(copyOfGround, move, numberOfSafeMoves);
                if (isMoveSafe)
                    return move;
            }

            return GetSafeMove(--numberOfSafeMoves);
        }

        private bool GetIfMoveIsSafe(GameGround gameGround, Move move, int numberOfSafeMoves)
        {
            if (numberOfSafeMoves == 0)
                return true;

            var ourPlayer = gameGround.OurHeroicPlayer;

            Direction absoluteDirection = DirectionHelper.GetAbsoluteDirection(ourPlayer.Direction.Value, move);

            Point nextPoint = DirectionHelper.GetNextPoint(ourPlayer.CurrentPosition, absoluteDirection);

            if (nextPoint.X >= gameGround.SizeOfTable || nextPoint.X < 0 || nextPoint.Y >= gameGround.SizeOfTable || nextPoint.Y < 0)
                return false;

            if (gameGround[nextPoint.X, nextPoint.Y] != 0)
                return false;

            if (IsCrossColision(nextPoint, absoluteDirection))
                return false;

            if (CalculatePossibleMovesOfOtherPlayers().Any(x => x.Equals(nextPoint)))
                return false;

            numberOfSafeMoves--;

            var newGround = gameGround.MakeACopy();

            newGround.SimulateStateAfterOurMove(nextPoint);

            foreach (var nextMove in _moveList)
            {
                if (GetIfMoveIsSafe(newGround, nextMove, numberOfSafeMoves))
                    return true;
            }
            return false;
        }

        private bool IsCrossColision(Point newPosition, Direction direction)
        {
            switch (direction)
            {
                case Direction.TopRight: return (_currentGameGround[newPosition.X, newPosition.Y + 1] != 0) && (_currentGameGround[newPosition.X - 1, newPosition.Y] != 0);
                case Direction.BottomRight: return (_currentGameGround[newPosition.X, newPosition.Y - 1] != 0) && (_currentGameGround[newPosition.X - 1, newPosition.Y] != 0);
                case Direction.BottomLeft: return (_currentGameGround[newPosition.X, newPosition.Y - 1] != 0) && (_currentGameGround[newPosition.X + 1, newPosition.Y] != 0);
                case Direction.TopLeft: return (_currentGameGround[newPosition.X, newPosition.Y + 1] != 0) && (_currentGameGround[newPosition.X + 1, newPosition.Y] != 0);
            }

            return false;

        }

        #endregion
     
        private IList<Point> CalculatePossibleMovesOfOtherPlayers()
        {
            List<Point> points = new List<Point>();

            foreach (var player in _otherPlayers.Where(x => x.IsDown == false))
            {
                foreach (var move in _moveList)
                {
                    if (player.Direction == null)
                        continue;

                    var absoluteDirection = DirectionHelper.GetAbsoluteDirection(player.Direction.Value, move);

                    points.Add(DirectionHelper.GetNextPoint(player.CurrentPosition, absoluteDirection));            
                }
            }

            return points;
        }
    }
}

