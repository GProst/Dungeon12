﻿using System;

namespace Dungeon.Types
{
    public class Rectangle
    {
        public static Rectangle Empty => new Rectangle();

        public Rectangle()
        {
        }
        
        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Rectangle(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public double X { get; set; }

        public float Xf => (float)X;

        public int Xi => (int)X;

        public double Y { get; set; }

        public float Yf => (float)Y;

        public int Yi => (int)Y;

        public double Width { get; set; }

        public double Height { get; set; }

        public float Heightf => (float)Height;

        public float Widthf => (float)Width;

        public int Heighti => (int)Height;

        public int Widthi => (int)Width;

        public float xMax => Xf+ Widthf;

        public float yMax => Yf+ Heightf;

        public bool Overlaps(Rectangle other)
        {
            var x1 = Math.Max(this.X, other.X);
            var x2 = Math.Min(this.X + this.Width, other.X + other.Width);
            var y1 = Math.Max(this.Y, other.Y);
            var y2 = Math.Min(this.Y + this.Height, other.Y + other.Height);

            if (x2 >= x1 && y2 >= y1)
            {
                return true;
            }

            return false;
        }

        public Point Pos
        {
            get => new(this.X, this.Y);
            set
            {
                this.X = value?.X ?? default;
                this.Y = value?.Y ?? default;
            }            
        }

        public Point Size
        {
            get
            {
                return new Point(this.Width, this.Height);
            }
        }

        public bool IntersectsWithOrContains(Rectangle b) => this.IntersectsWith(b) || this.Contains(b.X, b.Y);

        public bool Contains(double x, double y)
        {
            return ((x >= X) && (x < X+Width) &&
                (y >= Y) && (y < Y+Height));
        }

        public bool IntersectsWith(Rectangle b)
        {
            var x1 = Math.Max(X, b.X);
            var x2 = Math.Min(X + Width, b.X + b.Width);
            var y1 = Math.Max(Y, b.Y);
            var y2 = Math.Min(Y + Height, b.Y + b.Height);

            if (x2 >= x1 && y2 >= y1)
            {
                return true;
            }

            return false;
        }

        public bool Equals(Rectangle obj)
            => obj.Width == this.Width
            && obj.Height == this.Height
            && obj.X == this.X
            && obj.Y == this.Y;
    }
}
