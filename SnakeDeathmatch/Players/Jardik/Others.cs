﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeDeathmatch.Players.Jardik
{
    public class Others
    {
        private int[,] _oldgameSurround;
        int size = 0;

        public List<Other> OthersList { get; set; }

        public void  Update(int [,] gameSurround)
        {
            if (OthersList == null)
            {
                OthersList = new List<Other>();
                size = gameSurround.GetUpperBound(0)+1;
                  for (int x = 0; x < size; x++)
                    {
                        for (int y = 0; y < size; y++)
                        {
                            if (gameSurround[x, y] != 0 && gameSurround[x, y] != 1)
                            {
                                OthersList.Add(new Other { Position = new Position(x, y), Id = gameSurround[x, y] });
                            }
                        }
                    }
                  _oldgameSurround = gameSurround;
                  return;
            }

            foreach (var o in OthersList)
            {
                foreach (var dir in Enum.GetValues(typeof(Direction)))
                {
                    var p = o.Position.Copy();
                    p.Update((Direction)dir);
                    if (!p.IsInCollission(size))
                    {
                        if (gameSurround[p.X,p.Y] == o.Id && _oldgameSurround[p.X,p.Y] != o.Id)
                        {
                            o.Position = p;
                            o.Direction = (Direction)dir;
                            break;
                        }
                    }
                }
            }
            _oldgameSurround = (int [,])gameSurround.Clone();
        }
    }

    public class Other
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        public Direction Direction { get; set; }
    }
}
