﻿using Dungeon.Resources;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace Dungeon.Monogame
{
    public class DataBaseContentResolver : ContentResolver
    {
        public override Stream Resolve(string contentPath)
        {
            return ResourceLoader.Load(contentPath).Stream;
        }
    }
}
