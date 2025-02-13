﻿namespace Dungeon.Drawing.Impl
{
    using System;
    using System.Collections.Generic;
    using Dungeon.Types;
    using Dungeon.View.Enums;
    using Dungeon.View.Interfaces;

    public class DrawablePath : IDrawablePath
    {
        public string Uid { get; } = Guid.NewGuid().ToString();

        public float Depth { get; set; } = 1;
        public bool Fill { get; set; }
        public IDrawColor BackgroundColor { get; set; }
        public IDrawColor ForegroundColor { get; set; }
        public Rectangle Region { get; set; }

        public List<Point> Paths = new List<Point>();
        public IEnumerable<Point> Path => Paths;

        public float Angle { get; set; }

        public string Texture { get; set; }

        public PathPredefined PathPredefined { get; set; }

        public float Radius { get; set; }
    }
}