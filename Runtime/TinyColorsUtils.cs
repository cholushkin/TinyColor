using System;

namespace TinyColorLib
{
    public static class TinyColorsUtils
    {
        [Serializable]
        public class ColorInfo
        {
            public string Hex; // hex8
            public int Dec; // color as a number
            public string HSL; // HSLA
            public string HSV; // HSVA
            public string Name; // name of the color or "custom" if there is no predefined name
            public string RGB; // RGBA
            public string RGBA256; // RGBA256
            public bool IsDark;
            public bool IsMonochrome;
            public float Luminance;

            public ColorInfo(TinyColor color)
            {
                Hex = color.ToHex8String();
                Dec = color.ToNumber();
                HSL = color.ToHSLA().ToString();
                HSV = color.ToHSVA().ToString();
                Name = color.ToName();
                RGB = color.ToRGB().ToString();
                RGBA256 = color.ToRGBA256().ToString();
                IsDark = color.IsDark();
                IsMonochrome = color.IsMonochrome();
                Luminance = color.GetLuminance();
            }
        }

        public static ColorInfo GetColorInfo(this TinyColor color)
        {
            return new ColorInfo(color);
        }
    }
}

