﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Dungeon.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace Dungeon.Monogame
{
    public static class MonogameExtensions
    {
        public static void SetPixel(this Texture2D texture2D, int x, int y, Color c)
        {
            Rectangle r = new Rectangle(x, y, 1, 1);
            Color[] color = new Color[1];
            color[0] = c;

            texture2D.SetData(0, r, color, 0, 1);
        }

        public static Color GetPixel(this Texture2D texture2D, int x, int y)
        {
            Rectangle r = new Rectangle(x, y, 1, 1);
            Color[] color = new Color[1];
            texture2D.GetData(0, r, color, 0, 1);
            return color[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="a">0-255</param>
        /// <returns></returns>
        public static Color AddOpacity(this Color c, float a)
            => SetOpacity(c, c.A + a);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="a">0-255</param>
        /// <returns></returns>
        public static Color SetOpacity(this Color c, float a)
        {
            return new Color(c.R, c.G, c.B, a);
        }

        private static readonly Dictionary<float, Color> ColorCache = new Dictionary<float, Color>();

        private static float Sum(IDrawColor drawColor) => ((float)drawColor.R) + ((float)drawColor.B) + ((float)drawColor.G) + ((float)drawColor.A);

        public static Color Convert(this IDrawColor drawColor)
        {
            var hash = Sum(drawColor);
            if (!ColorCache.TryGetValue(hash, out var color))
            {
                color = new Color(drawColor.R, drawColor.G, drawColor.B, drawColor.A);
                ColorCache.Add(hash, color);
            }

            return color;
        }
    }
}