﻿using System;
using SnakeDeathmatch.Interface;

namespace SnakeDeathmatch.Players.Vazba
{
    public class FirstStrategy : IStrategy
    {
        private const int WTF = 18;

        private int[,] _playground = null;

        public Move GetNextMove(int[,] playground, Snakes snakes)
        {
            _playground = playground;
            Me me = snakes.Me;

            Next next = me.GetNext(playground);

            int depthLeft = next.Left.HasValue ? GetDepth(next.Left.Value, 0) : 0;
            int depthStraight = (depthLeft != WTF) && next.Straight.HasValue ? GetDepth(next.Straight.Value, 0) : 0;
            int depthRight = (depthLeft != WTF && depthStraight != WTF) && next.Right.HasValue ? GetDepth(next.Right.Value, 0) : 0;

            _playground = null;

            if (depthLeft >= depthStraight && depthLeft >= depthRight) return Move.Left;
            if (depthStraight >= depthLeft && depthStraight >= depthRight) return Move.Straight;
            return Move.Right;
        }

        private int GetDepth(Me me, int level)
        {
            _playground[me.P.X, me.P.Y] = Me.Id;

            if (level >= WTF)
                return WTF;

            int result = level;

            Next next = me.GetNext(_playground);

            if (next.Left.HasValue)
                result = Math.Max(result, GetDepth(next.Left.Value, level + 1));

            if (next.Straight.HasValue)
                result = Math.Max(result, GetDepth(next.Straight.Value, level + 1));

            if (next.Right.HasValue)
                result = Math.Max(result, GetDepth(next.Right.Value, level + 1));

            _playground[me.P.X, me.P.Y] = 0;

            return result;
        }
    }
}