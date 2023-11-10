namespace TinyColor
{
    public static class TinyColorsUtils
    {
        public class ColorInfo
        {
            public string Hex; // hex8
            public int Dec; // color as a number
            public string HSL; // HSLA
            public string HSV; // HSVA
            public string Name; // name of the color or "custom" if there is no predefined name
            public string RGB; // RGBA
            public bool IsDark;
            public bool IsMonochrome;
            public float Luminance;
        }

        public static ColorInfo GetColorInfo(this TinyColor color)
        {
            return new ColorInfo();
        }
    }
}

