using System;
using UnityEngine;
using static TinyColor.TinyColor;

namespace TinyColor
{
    public static class Conversion
    {
        public static TinyColor.RGB IntToRGB(int val)
        {
            byte r = (byte)(val >> 16);
            byte g = (byte)((val & 0xff00) >> 8);
            byte b = (byte)(val & 0xff);

            UnityEngine.Color clr = new Color32(r, g, b, 255);
            return new TinyColor.RGB(clr.r, clr.g, clr.b);
        }


        public static float HueToRGB(float p, float q, float t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;
            if (t < 1 / 6f) return p + (q - p) * 6 * t;
            if (t < 1 / 2f) return q;
            if (t < 2 / 3f) return p + (q - p) * (2 / 3f - t) * 6;
            return p;
        }


        // Hue(H) : Normally measured in degrees, the range is 0 to 360 degrees in a color wheel,
        // where 0 and 360 represent red, 120 represents green, 240 represents blue, and the intermediate values correspond to other colors.
        // Saturation(S): Represents the purity of the color and is measured as a percentage.
        // It ranges from 0 (a shade of gray) to 1.0 (full saturation).
        // Lightness(L) : Also represented as a percentage, it determines how much light is emitted or reflected by the color.
        // The range is 0 (black) to 1.0 (white), with 0.5 representing the pure color.
        public static RGB HSLToRGB(float h, float s, float l)
        {
            h = Mathf.Repeat(h, 360f) / 360f;
            s = Mathf.Clamp01(s);
            l = Mathf.Clamp01(l);

            float r, g, b;

            if (s == 0)
            {
                r = g = b = l;
            }
            else
            {
                float q = l < 0.5f ? l * (1f + s) : l + s - l * s;
                float p = 2f * l - q;
                r = HueToRGB(p, q, h + 1f / 3f);
                g = HueToRGB(p, q, h);
                b = HueToRGB(p, q, h - 1f / 3f);
            }

            return new RGB(r, g, b);
        }


        public static RGB HSVToRGB(float h, float s, float v)
        {
            h = Mathf.Repeat(h, 360f) / 360f * 6;
            s = Mathf.Clamp01(s);
            v = Mathf.Clamp01(v);

            int i = (int)h;
            float f = h - i;
            float p = v * (1f - s);
            float q = v * (1f - f * s);
            float t = v * (1f - (1f - f) * s);

            int mod = i % 6;
            float[] colorComponentsR = { v, q, p, p, t, v };
            float[] colorComponentsG = { t, v, v, q, p, p };
            float[] colorComponentsB = { p, p, t, v, v, q };

            float r = colorComponentsR[mod];
            float g = colorComponentsG[mod];
            float b = colorComponentsB[mod];

            return new RGB(r, g, b);
        }


        public static HSL RGBToHSL(float r, float g, float b)
        {
            r = Mathf.Clamp01(r);
            g = Mathf.Clamp01(g);
            b = Mathf.Clamp01(b);

            float max = Mathf.Max(r, g, b);
            float min = Mathf.Min(r, g, b);
            float h = 0f;
            float s = 0f;
            float l = (max + min) / 2f;

            if (max == min)
            {
                s = 0;
                h = 0; // achromatic
            }
            else
            {
                float d = max - min;
                s = l > 0.5f ? d / (2f - max - min) : d / (max + min);
                switch (max)
                {
                    case float _ when max == r:
                        h = (g - b) / d + (g < b ? 6 : 0);
                        break;
                    case float _ when max == g:
                        h = (b - r) / d + 2;
                        break;
                    case float _ when max == b:
                        h = (r - g) / d + 4;
                        break;
                    default:
                        break;
                }

                h /= 6f;
            }
            return new HSL(h * 360f, s, l);
        }


        public static HSV RGBToHSV(float r, float g, float b)
        {
            r = Mathf.Clamp01(r);
            g = Mathf.Clamp01(g);
            b = Mathf.Clamp01(b);

            float max = Mathf.Max(r, Mathf.Max(g, b));
            float min = Mathf.Min(r, Mathf.Min(g, b));
            float h = 0;
            float v = max;
            float d = max - min;
            float s = max == 0 ? 0 : d / max;

            if (max == min)
            {
                h = 0; // achromatic
            }
            else
            {
                if (max == r)
                {
                    h = (g - b) / d + (g < b ? 6 : 0);
                }
                else if (max == g)
                {
                    h = (b - r) / d + 2;
                }
                else if (max == b)
                {
                    h = (r - g) / d + 4;
                }

                h /= 6;
            }

            return new HSV(h * 360f, s, v);
        }
    }
}