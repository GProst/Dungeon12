﻿using Dungeon.Types;

namespace Dungeon.Physics
{
    public class PhysicalPosition
    {
        public PhysicalPosition() { }

        public PhysicalPosition(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public Point ToPoint() => new Point(X, Y);
    }
}