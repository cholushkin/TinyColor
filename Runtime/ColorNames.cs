using System.Collections.Generic;
using System.Reflection;

namespace TinyColorLib
{
    public static class Color
    {
        static public Dictionary<string, TinyColor> Colors;

        static Color()
        {
            Colors = new Dictionary<string, TinyColor>();
            var colorProperties = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static);
            foreach (var property in colorProperties)
            {
                if (property.PropertyType != typeof(UnityEngine.Color))
                    continue;

                UnityEngine.Color color = (UnityEngine.Color)property.GetValue(null, null);
                Colors.Add(property.Name.ToLower(), new TinyColor(color));
            }
        }

        public static UnityEngine.Color AliceBlue { get; } = new UnityEngine.Color(240 / 255.0f, 248 / 255.0f, 255 / 255.0f);
        public static UnityEngine.Color AntiqueWhite { get; } = new UnityEngine.Color(250 / 255.0f, 235 / 255.0f, 215 / 255.0f);
        public static UnityEngine.Color Aqua { get; } = new UnityEngine.Color(0 / 255.0f, 255 / 255.0f, 255 / 255.0f);
        public static UnityEngine.Color Aquamarine { get; } = new UnityEngine.Color(127 / 255.0f, 255 / 255.0f, 212 / 255.0f);
        public static UnityEngine.Color Azure { get; } = new UnityEngine.Color(240 / 255.0f, 255 / 255.0f, 255 / 255.0f);
        public static UnityEngine.Color Beige { get; } = new UnityEngine.Color(245 / 255.0f, 245 / 255.0f, 220 / 255.0f);
        public static UnityEngine.Color Bisque { get; } = new UnityEngine.Color(255 / 255.0f, 228 / 255.0f, 196 / 255.0f);
        public static UnityEngine.Color Black { get; } = new UnityEngine.Color(0 / 255.0f, 0 / 255.0f, 0 / 255.0f);
        public static UnityEngine.Color BlanchedAlmond { get; } = new UnityEngine.Color(255 / 255.0f, 235 / 255.0f, 205 / 255.0f);
        public static UnityEngine.Color Blue { get; } = new UnityEngine.Color(0 / 255.0f, 0 / 255.0f, 255 / 255.0f);
        public static UnityEngine.Color BlueViolet { get; } = new UnityEngine.Color(138 / 255.0f, 43 / 255.0f, 226 / 255.0f);
        public static UnityEngine.Color Brown { get; } = new UnityEngine.Color(165 / 255.0f, 42 / 255.0f, 42 / 255.0f);
        public static UnityEngine.Color BurlyWood { get; } = new UnityEngine.Color(222 / 255.0f, 184 / 255.0f, 135 / 255.0f);
        public static UnityEngine.Color CadetBlue { get; } = new UnityEngine.Color(95 / 255.0f, 158 / 255.0f, 160 / 255.0f);
        public static UnityEngine.Color Chartreuse { get; } = new UnityEngine.Color(127 / 255.0f, 255 / 255.0f, 0 / 255.0f);
        public static UnityEngine.Color Chocolate { get; } = new UnityEngine.Color(210 / 255.0f, 105 / 255.0f, 30 / 255.0f);
        public static UnityEngine.Color Coral { get; } = new UnityEngine.Color(255 / 255.0f, 127 / 255.0f, 80 / 255.0f);
        public static UnityEngine.Color CornflowerBlue { get; } = new UnityEngine.Color(100 / 255.0f, 149 / 255.0f, 237 / 255.0f);
        public static UnityEngine.Color Cornsilk { get; } = new UnityEngine.Color(255 / 255.0f, 248 / 255.0f, 220 / 255.0f);
        public static UnityEngine.Color Crimson { get; } = new UnityEngine.Color(220 / 255.0f, 20 / 255.0f, 60 / 255.0f);
        public static UnityEngine.Color Cyan { get; } = new UnityEngine.Color(0 / 255.0f, 255 / 255.0f, 255 / 255.0f);
        public static UnityEngine.Color DarkBlue { get; } = new UnityEngine.Color(0 / 255.0f, 0 / 255.0f, 139 / 255.0f);
        public static UnityEngine.Color DarkCyan { get; } = new UnityEngine.Color(0 / 255.0f, 139 / 255.0f, 139 / 255.0f);
        public static UnityEngine.Color DarkGoldenrod { get; } = new UnityEngine.Color(184 / 255.0f, 134 / 255.0f, 11 / 255.0f);
        public static UnityEngine.Color DarkGray { get; } = new UnityEngine.Color(169 / 255.0f, 169 / 255.0f, 169 / 255.0f);
        public static UnityEngine.Color DarkGreen { get; } = new UnityEngine.Color(0 / 255.0f, 100 / 255.0f, 0 / 255.0f);
        public static UnityEngine.Color DarkGrey { get; } = new UnityEngine.Color(169 / 255.0f, 169 / 255.0f, 169 / 255.0f);
        public static UnityEngine.Color DarkKhaki { get; } = new UnityEngine.Color(189 / 255.0f, 183 / 255.0f, 107 / 255.0f);
        public static UnityEngine.Color DarkMagenta { get; } = new UnityEngine.Color(139 / 255.0f, 0 / 255.0f, 139 / 255.0f);
        public static UnityEngine.Color DarkOliveGreen { get; } = new UnityEngine.Color(85 / 255.0f, 107 / 255.0f, 47 / 255.0f);
        public static UnityEngine.Color DarkOrange { get; } = new UnityEngine.Color(255 / 255.0f, 140 / 255.0f, 0 / 255.0f);
        public static UnityEngine.Color DarkOrchid { get; } = new UnityEngine.Color(153 / 255.0f, 50 / 255.0f, 204 / 255.0f);
        public static UnityEngine.Color DarkRed { get; } = new UnityEngine.Color(139 / 255.0f, 0 / 255.0f, 0 / 255.0f);
        public static UnityEngine.Color DarkSalmon { get; } = new UnityEngine.Color(233 / 255.0f, 150 / 255.0f, 122 / 255.0f);
        public static UnityEngine.Color DarkSeaGreen { get; } = new UnityEngine.Color(143 / 255.0f, 188 / 255.0f, 143 / 255.0f);
        public static UnityEngine.Color DarkSlateBlue { get; } = new UnityEngine.Color(72 / 255.0f, 61 / 255.0f, 139 / 255.0f);
        public static UnityEngine.Color DarkSlateGray { get; } = new UnityEngine.Color(47 / 255.0f, 79 / 255.0f, 79 / 255.0f);
        public static UnityEngine.Color DarkSlateGrey { get; } = new UnityEngine.Color(47 / 255.0f, 79 / 255.0f, 79 / 255.0f);
        public static UnityEngine.Color DarkTurquoise { get; } = new UnityEngine.Color(0 / 255.0f, 206 / 255.0f, 209 / 255.0f);
        public static UnityEngine.Color DarkViolet { get; } = new UnityEngine.Color(148 / 255.0f, 0 / 255.0f, 211 / 255.0f);
        public static UnityEngine.Color DeepPink { get; } = new UnityEngine.Color(255 / 255.0f, 20 / 255.0f, 147 / 255.0f);
        public static UnityEngine.Color DeepSkyBlue { get; } = new UnityEngine.Color(0 / 255.0f, 191 / 255.0f, 255 / 255.0f);
        public static UnityEngine.Color DimGray { get; } = new UnityEngine.Color(105 / 255.0f, 105 / 255.0f, 105 / 255.0f);
        public static UnityEngine.Color DimGrey { get; } = new UnityEngine.Color(105 / 255.0f, 105 / 255.0f, 105 / 255.0f);
        public static UnityEngine.Color DodgerBlue { get; } = new UnityEngine.Color(30 / 255.0f, 144 / 255.0f, 255 / 255.0f);
        public static UnityEngine.Color Firebrick { get; } = new UnityEngine.Color(178 / 255.0f, 34 / 255.0f, 34 / 255.0f);
        public static UnityEngine.Color FloralWhite { get; } = new UnityEngine.Color(255 / 255.0f, 250 / 255.0f, 240 / 255.0f);
        public static UnityEngine.Color ForestGreen { get; } = new UnityEngine.Color(34 / 255.0f, 139 / 255.0f, 34 / 255.0f);
        public static UnityEngine.Color Fuchsia { get; } = new UnityEngine.Color(255 / 255.0f, 0 / 255.0f, 255 / 255.0f);
        public static UnityEngine.Color Gainsboro { get; } = new UnityEngine.Color(220 / 255.0f, 220 / 255.0f, 220 / 255.0f);
        public static UnityEngine.Color GhostWhite { get; } = new UnityEngine.Color(248 / 255.0f, 248 / 255.0f, 255 / 255.0f);
        public static UnityEngine.Color Gold { get; } = new UnityEngine.Color(255 / 255.0f, 215 / 255.0f, 0 / 255.0f);
        public static UnityEngine.Color Goldenrod { get; } = new UnityEngine.Color(218 / 255.0f, 165 / 255.0f, 32 / 255.0f);
        public static UnityEngine.Color Gray { get; } = new UnityEngine.Color(128 / 255.0f, 128 / 255.0f, 128 / 255.0f);
        public static UnityEngine.Color Green { get; } = new UnityEngine.Color(0 / 255.0f, 128 / 255.0f, 0 / 255.0f);
        public static UnityEngine.Color GreenYellow { get; } = new UnityEngine.Color(173 / 255.0f, 255 / 255.0f, 47 / 255.0f);
        public static UnityEngine.Color Grey { get; } = new UnityEngine.Color(128 / 255.0f, 128 / 255.0f, 128 / 255.0f);
        public static UnityEngine.Color Honeydew { get; } = new UnityEngine.Color(240 / 255.0f, 255 / 255.0f, 240 / 255.0f);
        public static UnityEngine.Color HotPink { get; } = new UnityEngine.Color(255 / 255.0f, 105 / 255.0f, 180 / 255.0f);
        public static UnityEngine.Color IndianRed { get; } = new UnityEngine.Color(205 / 255.0f, 92 / 255.0f, 92 / 255.0f);
        public static UnityEngine.Color Indigo { get; } = new UnityEngine.Color(75 / 255.0f, 0 / 255.0f, 130 / 255.0f);
        public static UnityEngine.Color Ivory { get; } = new UnityEngine.Color(255 / 255.0f, 255 / 255.0f, 240 / 255.0f);
        public static UnityEngine.Color Khaki { get; } = new UnityEngine.Color(240 / 255.0f, 230 / 255.0f, 140 / 255.0f);
        public static UnityEngine.Color Lavender { get; } = new UnityEngine.Color(230 / 255.0f, 230 / 255.0f, 250 / 255.0f);
        public static UnityEngine.Color LawnGreen { get; } = new UnityEngine.Color(124 / 255.0f, 252 / 255.0f, 0 / 255.0f);
        public static UnityEngine.Color LemonChiffon { get; } = new UnityEngine.Color(255 / 255.0f, 250 / 255.0f, 205 / 255.0f);
        public static UnityEngine.Color LightBlue { get; } = new UnityEngine.Color(173 / 255.0f, 216 / 255.0f, 230 / 255.0f);
        public static UnityEngine.Color LightCoral { get; } = new UnityEngine.Color(240 / 255.0f, 128 / 255.0f, 128 / 255.0f);
        public static UnityEngine.Color LightCyan { get; } = new UnityEngine.Color(224 / 255.0f, 255 / 255.0f, 255 / 255.0f);
        public static UnityEngine.Color LightGoldenrodYellow { get; } = new UnityEngine.Color(250 / 255.0f, 250 / 255.0f, 210 / 255.0f);
        public static UnityEngine.Color LightGray { get; } = new UnityEngine.Color(211 / 255.0f, 211 / 255.0f, 211 / 255.0f);
        public static UnityEngine.Color LightGreen { get; } = new UnityEngine.Color(144 / 255.0f, 238 / 255.0f, 144 / 255.0f);
        public static UnityEngine.Color LightGrey { get; } = new UnityEngine.Color(211 / 255.0f, 211 / 255.0f, 211 / 255.0f);
        public static UnityEngine.Color LightPink { get; } = new UnityEngine.Color(255 / 255.0f, 182 / 255.0f, 193 / 255.0f);
        public static UnityEngine.Color LightSalmon { get; } = new UnityEngine.Color(255 / 255.0f, 160 / 255.0f, 122 / 255.0f);
        public static UnityEngine.Color LightSeaGreen { get; } = new UnityEngine.Color(32 / 255.0f, 178 / 255.0f, 170 / 255.0f);
        public static UnityEngine.Color LightSkyBlue { get; } = new UnityEngine.Color(135 / 255.0f, 206 / 255.0f, 250 / 255.0f);
        public static UnityEngine.Color LightSlateGray { get; } = new UnityEngine.Color(119 / 255.0f, 136 / 255.0f, 153 / 255.0f);
        public static UnityEngine.Color LightSlateGrey { get; } = new UnityEngine.Color(119 / 255.0f, 136 / 255.0f, 153 / 255.0f);
        public static UnityEngine.Color LightSteelBlue { get; } = new UnityEngine.Color(176 / 255.0f, 196 / 255.0f, 222 / 255.0f);
        public static UnityEngine.Color LightYellow { get; } = new UnityEngine.Color(255 / 255.0f, 255 / 255.0f, 224 / 255.0f);
        public static UnityEngine.Color Lime { get; } = new UnityEngine.Color(0 / 255.0f, 255 / 255.0f, 0 / 255.0f);
        public static UnityEngine.Color LimeGreen { get; } = new UnityEngine.Color(50 / 255.0f, 205 / 255.0f, 50 / 255.0f);
        public static UnityEngine.Color Linen { get; } = new UnityEngine.Color(250 / 255.0f, 240 / 255.0f, 230 / 255.0f);
        public static UnityEngine.Color Magenta { get; } = new UnityEngine.Color(255 / 255.0f, 0 / 255.0f, 255 / 255.0f);
        public static UnityEngine.Color Maroon { get; } = new UnityEngine.Color(128 / 255.0f, 0 / 255.0f, 0 / 255.0f);
        public static UnityEngine.Color MediumAquamarine { get; } = new UnityEngine.Color(102 / 255.0f, 205 / 255.0f, 170 / 255.0f);
        public static UnityEngine.Color MediumBlue { get; } = new UnityEngine.Color(0 / 255.0f, 0 / 255.0f, 205 / 255.0f);
        public static UnityEngine.Color MediumOrchid { get; } = new UnityEngine.Color(186 / 255.0f, 85 / 255.0f, 211 / 255.0f);
        public static UnityEngine.Color MediumPurple { get; } = new UnityEngine.Color(147 / 255.0f, 112 / 255.0f, 219 / 255.0f);
        public static UnityEngine.Color MediumSeaGreen { get; } = new UnityEngine.Color(60 / 255.0f, 179 / 255.0f, 113 / 255.0f);
        public static UnityEngine.Color MediumSlateBlue { get; } = new UnityEngine.Color(123 / 255.0f, 104 / 255.0f, 238 / 255.0f);
        public static UnityEngine.Color MediumSpringGreen { get; } = new UnityEngine.Color(0 / 255.0f, 250 / 255.0f, 154 / 255.0f);
        public static UnityEngine.Color MediumTurquoise { get; } = new UnityEngine.Color(72 / 255.0f, 209 / 255.0f, 204 / 255.0f);
        public static UnityEngine.Color MediumVioletRed { get; } = new UnityEngine.Color(199 / 255.0f, 21 / 255.0f, 133 / 255.0f);
        public static UnityEngine.Color MidnightBlue { get; } = new UnityEngine.Color(25 / 255.0f, 25 / 255.0f, 112 / 255.0f);
        public static UnityEngine.Color MintCream { get; } = new UnityEngine.Color(245 / 255.0f, 255 / 255.0f, 250 / 255.0f);
        public static UnityEngine.Color MistyRose { get; } = new UnityEngine.Color(255 / 255.0f, 228 / 255.0f, 225 / 255.0f);
        public static UnityEngine.Color Moccasin { get; } = new UnityEngine.Color(255 / 255.0f, 228 / 255.0f, 181 / 255.0f);
        public static UnityEngine.Color NavajoWhite { get; } = new UnityEngine.Color(255 / 255.0f, 222 / 255.0f, 173 / 255.0f);
        public static UnityEngine.Color Navy { get; } = new UnityEngine.Color(0 / 255.0f, 0 / 255.0f, 128 / 255.0f);
        public static UnityEngine.Color OldLace { get; } = new UnityEngine.Color(253 / 255.0f, 245 / 255.0f, 230 / 255.0f);
        public static UnityEngine.Color Olive { get; } = new UnityEngine.Color(128 / 255.0f, 128 / 255.0f, 0 / 255.0f);
        public static UnityEngine.Color OliveDrab { get; } = new UnityEngine.Color(107 / 255.0f, 142 / 255.0f, 35 / 255.0f);
        public static UnityEngine.Color Orange { get; } = new UnityEngine.Color(255 / 255.0f, 165 / 255.0f, 0 / 255.0f);
        public static UnityEngine.Color OrangeRed { get; } = new UnityEngine.Color(255 / 255.0f, 69 / 255.0f, 0 / 255.0f);
        public static UnityEngine.Color Orchid { get; } = new UnityEngine.Color(218 / 255.0f, 112 / 255.0f, 214 / 255.0f);
        public static UnityEngine.Color PaleGoldenrod { get; } = new UnityEngine.Color(238 / 255.0f, 232 / 255.0f, 170 / 255.0f);
        public static UnityEngine.Color PaleGreen { get; } = new UnityEngine.Color(152 / 255.0f, 251 / 255.0f, 152 / 255.0f);
        public static UnityEngine.Color PaleTurquoise { get; } = new UnityEngine.Color(175 / 255.0f, 238 / 255.0f, 238 / 255.0f);
        public static UnityEngine.Color PaleVioletRed { get; } = new UnityEngine.Color(219 / 255.0f, 112 / 255.0f, 147 / 255.0f);
        public static UnityEngine.Color PapayaWhip { get; } = new UnityEngine.Color(255 / 255.0f, 239 / 255.0f, 213 / 255.0f);
        public static UnityEngine.Color PeachPuff { get; } = new UnityEngine.Color(255 / 255.0f, 218 / 255.0f, 185 / 255.0f);
        public static UnityEngine.Color Peru { get; } = new UnityEngine.Color(205 / 255.0f, 133 / 255.0f, 63 / 255.0f);
        public static UnityEngine.Color Pink { get; } = new UnityEngine.Color(255 / 255.0f, 192 / 255.0f, 203 / 255.0f);
        public static UnityEngine.Color Plum { get; } = new UnityEngine.Color(221 / 255.0f, 160 / 255.0f, 221 / 255.0f);
        public static UnityEngine.Color PowderBlue { get; } = new UnityEngine.Color(176 / 255.0f, 224 / 255.0f, 230 / 255.0f);
        public static UnityEngine.Color Purple { get; } = new UnityEngine.Color(128 / 255.0f, 0 / 255.0f, 128 / 255.0f);
        public static UnityEngine.Color RebeccaPurple { get; } = new UnityEngine.Color(102 / 255.0f, 51 / 255.0f, 153 / 255.0f);
        public static UnityEngine.Color Red { get; } = new UnityEngine.Color(255 / 255.0f, 0 / 255.0f, 0 / 255.0f);
        public static UnityEngine.Color RosyBrown { get; } = new UnityEngine.Color(188 / 255.0f, 143 / 255.0f, 143 / 255.0f);
        public static UnityEngine.Color RoyalBlue { get; } = new UnityEngine.Color(65 / 255.0f, 105 / 255.0f, 225 / 255.0f);
        public static UnityEngine.Color SaddleBrown { get; } = new UnityEngine.Color(139 / 255.0f, 69 / 255.0f, 19 / 255.0f);
        public static UnityEngine.Color Salmon { get; } = new UnityEngine.Color(250 / 255.0f, 128 / 255.0f, 114 / 255.0f);
        public static UnityEngine.Color SandyBrown { get; } = new UnityEngine.Color(244 / 255.0f, 164 / 255.0f, 96 / 255.0f);
        public static UnityEngine.Color SeaGreen { get; } = new UnityEngine.Color(46 / 255.0f, 139 / 255.0f, 87 / 255.0f);
        public static UnityEngine.Color Seashell { get; } = new UnityEngine.Color(255 / 255.0f, 245 / 255.0f, 238 / 255.0f);
        public static UnityEngine.Color Sienna { get; } = new UnityEngine.Color(160 / 255.0f, 82 / 255.0f, 45 / 255.0f);
        public static UnityEngine.Color Silver { get; } = new UnityEngine.Color(192 / 255.0f, 192 / 255.0f, 192 / 255.0f);
        public static UnityEngine.Color SkyBlue { get; } = new UnityEngine.Color(135 / 255.0f, 206 / 255.0f, 235 / 255.0f);
        public static UnityEngine.Color SlateBlue { get; } = new UnityEngine.Color(106 / 255.0f, 90 / 255.0f, 205 / 255.0f);
        public static UnityEngine.Color SlateGray { get; } = new UnityEngine.Color(112 / 255.0f, 128 / 255.0f, 144 / 255.0f);
        public static UnityEngine.Color SlateGrey { get; } = new UnityEngine.Color(112 / 255.0f, 128 / 255.0f, 144 / 255.0f);
        public static UnityEngine.Color Snow { get; } = new UnityEngine.Color(255 / 255.0f, 250 / 255.0f, 250 / 255.0f);
        public static UnityEngine.Color SpringGreen { get; } = new UnityEngine.Color(0 / 255.0f, 255 / 255.0f, 127 / 255.0f);
        public static UnityEngine.Color SteelBlue { get; } = new UnityEngine.Color(70 / 255.0f, 130 / 255.0f, 180 / 255.0f);
        public static UnityEngine.Color Tan { get; } = new UnityEngine.Color(210 / 255.0f, 180 / 255.0f, 140 / 255.0f);
        public static UnityEngine.Color Teal { get; } = new UnityEngine.Color(0 / 255.0f, 128 / 255.0f, 128 / 255.0f);
        public static UnityEngine.Color Thistle { get; } = new UnityEngine.Color(216 / 255.0f, 191 / 255.0f, 216 / 255.0f);
        public static UnityEngine.Color Tomato { get; } = new UnityEngine.Color(255 / 255.0f, 99 / 255.0f, 71 / 255.0f);
        public static UnityEngine.Color Turquoise { get; } = new UnityEngine.Color(64 / 255.0f, 224 / 255.0f, 208 / 255.0f);
        public static UnityEngine.Color Violet { get; } = new UnityEngine.Color(238 / 255.0f, 130 / 255.0f, 238 / 255.0f);
        public static UnityEngine.Color Wheat { get; } = new UnityEngine.Color(245 / 255.0f, 222 / 255.0f, 179 / 255.0f);
        public static UnityEngine.Color White { get; } = new UnityEngine.Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f);
        public static UnityEngine.Color WhiteSmoke { get; } = new UnityEngine.Color(245 / 255.0f, 245 / 255.0f, 245 / 255.0f);
        public static UnityEngine.Color Yellow { get; } = new UnityEngine.Color(255 / 255.0f, 255 / 255.0f, 0 / 255.0f);
        public static UnityEngine.Color YellowGreen { get; } = new UnityEngine.Color(154 / 255.0f, 205 / 255.0f, 50 / 255.0f);
    }
}
