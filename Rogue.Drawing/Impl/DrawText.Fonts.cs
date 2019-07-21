﻿namespace Rogue.Drawing
{
    using Rogue.View.Interfaces;

    public static class DrawTextFonts
    {
        public static T Montserrat<T>(this T drawText) where T : IDrawText
        {
            drawText.FontName = "Montserrat";
            drawText.FontAssembly = "Rogue.Resources";
            drawText.FontPath = "Rogue.Resources.Fonts.Mont.otf";

            return drawText;
        }

        public static T Triforce<T>(this T drawText) where T : IDrawText
        {
            drawText.FontName = "Triforce";
            drawText.FontAssembly = "Rogue.Resources";
            drawText.FontPath = null;

            return drawText;
        }
    }
}