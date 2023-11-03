using System.Collections.Generic;
using UnityEngine;

namespace TinyColor
{
    public static class Color
    {
        public static UnityEngine.Color AliceBlue { get; } = IntToColor(0xF0F8FF);
        public static UnityEngine.Color AntiqueWhite { get; } = IntToColor(0xFAEBD7);
        public static UnityEngine.Color Aqua { get; } = IntToColor(0x00FFFF);
        public static UnityEngine.Color Aquamarine { get; } = IntToColor(0x7FFFD4);
        public static UnityEngine.Color Azure { get; } = IntToColor(0xF0FFFF);
        public static UnityEngine.Color Beige { get; } = IntToColor(0xF5F5DC);
        public static UnityEngine.Color Bisque { get; } = IntToColor(0xFFE4C4);
        public static UnityEngine.Color Black { get; } = IntToColor(0x000000);
        public static UnityEngine.Color BlanchedAlmond { get; } = IntToColor(0xFFEBCD);
        public static UnityEngine.Color Blue { get; } = IntToColor(0x0000FF);
        public static UnityEngine.Color BlueViolet { get; } = IntToColor(0x8A2BE2);
        public static UnityEngine.Color Brown { get; } = IntToColor(0xA52A2A);
        public static UnityEngine.Color BurlyWood { get; } = IntToColor(0xDEB887);
        public static UnityEngine.Color CadetBlue { get; } = IntToColor(0x5F9EA0);
        public static UnityEngine.Color Chartreuse { get; } = IntToColor(0x7FFF00);

        // Add more colors as needed

        private static UnityEngine.Color IntToColor(int hexValue)
        {
            UnityEngine.Color color = new UnityEngine.Color(
                ((hexValue >> 16) & 0xFF) / 255.0f,
                ((hexValue >> 8) & 0xFF) / 255.0f,
                (hexValue & 0xFF) / 255.0f
            );
            return color;
        }
    }
}
