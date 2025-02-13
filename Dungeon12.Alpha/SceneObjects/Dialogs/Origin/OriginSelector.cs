﻿namespace Dungeon12.Drawing.SceneObjects.Dialogs.Origin
{
    using Dungeon;
    using Dungeon.Control;
    using Dungeon.Drawing;
    using Dungeon.Drawing.SceneObjects;
    using Dungeon12.Entities.Alive.Enums;
    using Dungeon.GameObjects;
    using System;
    using Dungeon12;

    public class OriginSelector : ColoredRectangle<EmptyGameComponent>
    {
        private readonly Action<Origins> select;
        public readonly Origins origin;

        public OriginSelector(Origins origin, Action<Origins> select):base(EmptyGameComponent.Empty)
        {
            this.origin = origin;
            this.select = select;

            Color = ConsoleColor.Black;
            Depth = 1;
            Fill = true;
            Opacity = 0.5;
            Round = 5;

            this.AddChild(new ImageObject($"Dungeon12.Resources.Images.Origin.{origin.ToString()}.png")
            {
                Width = 2,
                Height = 2,
                Left=.5,
                Top=.5
            });

            this.Height = 3;
            this.Width = 8;
            var t = this.AddTextCenter(new DrawText(origin.ToDisplay())
            {
                Size =24
            }.Triforce());

            t.Left = 2.5;
        }
       
        public override void Click(PointerArgs args)
        {
            select?.Invoke(origin);
        }
    }
}