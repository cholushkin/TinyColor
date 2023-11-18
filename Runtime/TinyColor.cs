using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace TinyColorLib
{
    public class TinyColor : ICloneable
    {
        #region Color conversion light data structures
        public class RGB
        {
            public float R, G, B;

            public RGB(float r, float g, float b)
            {
                R = r;
                G = g;
                B = b;
            }

            public RGB Normalize()
            {
                return new RGB(Mathf.Clamp01(R), Mathf.Clamp01(G), Mathf.Clamp01(B));
            }

            public override string ToString()
            {
                return $"{R} {G} {B}";
            }
        }


        public class RGBA : RGB
        {
            public float A;

            public RGBA(float r, float g, float b, float a)
                : base(r, g, b)
            {
                A = a;
            }

            public RGBA Normalize()
            {
                return new RGBA(Mathf.Clamp01(R), Mathf.Clamp01(G), Mathf.Clamp01(B), Mathf.Clamp01(A));
            }

            public override string ToString()
            {
                return $"{R} {G} {B} {A}";
            }
        }


        public class RGB256
        {
            public byte R;
            public byte G;
            public byte B;

            public RGB256(byte r, byte g, byte b)
            {
                R = r;
                G = g;
                B = b;
            }

            public override string ToString()
            {
                return $"{R} {G} {B}";
            }
        }


        public class RGBA256 : RGB256
        {
            public byte A;

            public RGBA256(byte r, byte g, byte b, byte a)
                : base(r, g, b)
            {
                A = a;
            }

            public override string ToString()
            {
                return $"{R} {G} {B} {A}";
            }
        }



        public class HSL
        {
            public float H, S, L;

            public HSL(float h, float s, float l)
            {
                H = h;
                S = s;
                L = l;
            }

            public HSL Normalize()
            {
                return new HSL(H, Mathf.Clamp01(S), Mathf.Clamp01(L));
            }

            public override string ToString()
            {
                return $"{H} {S} {L}";
            }
        }


        public class HSLA : HSL
        {
            public float A;

            public HSLA(float h, float s, float l, float a)
                : base(h, s, l)
            {
                A = a;
            }

            public HSLA Normalize()
            {
                return new HSLA(H, Mathf.Clamp01(S), Mathf.Clamp01(L), Mathf.Clamp01(A));
            }

            public override string ToString()
            {
                return $"{H} {S} {L} {A}";
            }
        }


        public class HSV
        {
            public float H, S, V;

            public HSV(float h, float s, float v)
            {
                H = h;
                S = s;
                V = v;
            }

            public HSV Normalize()
            {
                return new HSV(H, Mathf.Clamp01(S), Mathf.Clamp01(V));
            }

            public override string ToString()
            {
                return $"{H} {S} {V}";
            }
        }

        public class HSVA : HSV
        {
            public float A;

            public HSVA(float h, float s, float v, float a)
                : base(h, s, v)
            {
                A = a;
            }

            public HSVA Normalize()
            {
                return new HSVA(H, Mathf.Clamp01(S), Mathf.Clamp01(V), Mathf.Clamp01(A));
            }

            public override string ToString()
            {
                return $"{H} {S} {V} {A}";
            }
        }
        #endregion


        public float R;
        public float G;
        public float B;
        public float A;


        #region Constructors
        public TinyColor(UnityEngine.Color color)
        {
            R = color.r;
            G = color.g;
            B = color.b;
            A = color.a;
        }

        public TinyColor(UnityEngine.Color32 color32)
        {
            UnityEngine.Color color = color32;
            R = color.r;
            G = color.g;
            B = color.b;
            A = color.a;
        }

        public TinyColor(int color32) :
            this(Conversion.IntToRGB(color32))
        {
        }

        public TinyColor(RGB colorRGB)
        {
            R = colorRGB.R;
            G = colorRGB.G;
            B = colorRGB.B;
            A = 1.0f;
        }

        public TinyColor(RGBA colorRGBA)
        {
            R = colorRGBA.R;
            G = colorRGBA.G;
            B = colorRGBA.B;
            A = colorRGBA.A;
        }

        public TinyColor(RGB256 colorRGB256)
        {
            R = colorRGB256.R / 255f;
            G = colorRGB256.G / 255f;
            B = colorRGB256.B / 255f;
            A = 1.0f;
        }

        public TinyColor(RGBA256 colorRGBA256)
        {
            R = colorRGBA256.R / 255f;
            G = colorRGBA256.G / 255f;
            B = colorRGBA256.B / 255f;
            A = colorRGBA256.A / 255f;
        }

        public TinyColor(HSL colorHSL) :
            this(Conversion.HSLToRGB(colorHSL.H, colorHSL.S, colorHSL.L))
        {
        }

        public TinyColor(HSLA colorHSLA) :
            this(Conversion.HSLToRGB(colorHSLA.H, colorHSLA.S, colorHSLA.L))
        {
            A = colorHSLA.A;
        }

        public TinyColor(HSV colorHSV) :
            this(Conversion.HSVToRGB(colorHSV.H, colorHSV.S, colorHSV.V))
        {
        }

        public TinyColor(HSVA colorHSVA) :
            this(Conversion.HSVToRGB(colorHSVA.H, colorHSVA.S, colorHSVA.V))
        {
            A = colorHSVA.A;
        }

        public TinyColor(TinyColor tinyColor)
        {
            if (tinyColor == null)
            {
                R = G = B = A = A = 1;
                return;
            }
            R = tinyColor.R;
            G = tinyColor.G;
            B = tinyColor.B;
            A = tinyColor.A;
        }
        #endregion


        public TinyColor Normalize()
        {
            return new TinyColor(new RGBA(R, G, B, A).Normalize());
        }


        public object Clone()
        {
            return MemberwiseClone();
        }


        public bool Equals(TinyColor other)
        {
            var a = ToRGBA256();
            var b = other.ToRGBA256();
            return a.R.Equals(b.R) && a.G.Equals(b.G) && a.B.Equals(b.B) && a.A.Equals(b.A);
        }

        /*
         *  GetBrightness calculates the brightness of a color using a weighted sum of its red, green, and blue components. 
         *  This calculation is based on the formula outlined in the "Web Content Accessibility Guidelines (WCAG)" for determining color contrast 
         *  for accessibility (referenced in the comment with the link to W3C's AERT).
         *  
         *  The formula itself is derived from the formula for calculating the perceived luminance of a color. It uses different weightings
         *  for the red, green, and blue components based on the sensitivity of the human eye to these colors.
         *  
         *  The weights are:
         *  Red: 299
         *  Green: 587
         *  Blue: 114
         *  
         *  These weights are used because the human eye is more sensitive to green light and less sensitive to blue light compared to red. 
         *  Therefore, the contributions of each color channel to the overall brightness are weighted accordingly.
         *  The formula multiplies each color component by its respective weight, sums up these values, 
         *  and divides the total by 1000 to obtain a brightness value.
         *  
         *  This brightness value is often used in accessibility contexts to determine the contrast between foreground and background colors. 
         *  According to WCAG guidelines, text over a background should have sufficient contrast for readability, and this function can be 
         *  used to evaluate the brightness of the background to determine suitable text colors for readability.
         *  
         *  https://www.w3.org/TR/AERT/#color-contrast
        */
        public float GetBrightness() // 0..1
        {
            var rgb = ToRGB().Normalize();
            return (rgb.R * 299f + rgb.G * 587f + rgb.B * 114f) / 1000f;
        }


        public bool IsDark()
        {
            return GetBrightness() < 0.5f;
        }


        public bool IsLight()
        {
            return !IsDark();
        }


        // Returns the perceived luminance of a color, from 0-1.
        // http://www.w3.org/TR/2008/REC-WCAG20-20081211/#relativeluminancedef
        public float GetLuminance()
        {
            var r = R;
            var g = G;
            var b = B;

            if (R <= 0.03928f)
                r /= 12.92f;
            else
                r = Mathf.Pow((R + 0.055f) / 1.055f, 2.4f);

            if (G <= 0.03928f)
                g /= 12.92f;
            else
                g = Mathf.Pow((G + 0.055f) / 1.055f, 2.4f);

            if (B <= 0.03928f)
                b = B / 12.92f;
            else
                b = Mathf.Pow((B + 0.055f) / 1.055f, 2.4f);

            return 0.2126f * r + 0.7152f * g + 0.0722f * b;
        }


        // Returns whether the color is monochrome.
        public bool IsMonochrome()
        {
            return Mathf.Approximately(ToHSL().S, 0f);
        }


        // Lighten the color a given amount. Providing 1.0f will always return white.
        public TinyColor Lighten(float amount = 0.1f)
        {
            var hsl = ToHSL();
            hsl.L = Mathf.Clamp01(hsl.L + amount);
            return new TinyColor(hsl);
        }


        // Brighten the color a given amount, from 0 to 1.
        // amount - valid between 0-1
        public TinyColor Brighten(float amount = 0.1f)
        {
            var rgb = ToRGB();

            rgb.R = Mathf.Clamp01(rgb.R + amount);
            rgb.G = Mathf.Clamp01(rgb.G + amount);
            rgb.B = Mathf.Clamp01(rgb.B + amount);

            return new TinyColor(rgb);
        }

        // Darken the color a given amount, from 0 to 1.Providing 1 will always return black.
        public TinyColor Darken(float amount = 0.1f)
        {
            var hsl = ToHSL();
            hsl.L = Mathf.Clamp01(hsl.L - amount);
            return new TinyColor(hsl);
        }


        // Mix the current color a given amount with another color, from 0 to 1.
        // 0 means no mixing (return current color).
        public TinyColor Mix(TinyColor color, float amount = 0.5f)
        {
            var rgb1 = ToRGBA();
            var rgb2 = color.ToRGBA();

            float mixedAmount = Mathf.Clamp01(amount);
            rgb1.R = (rgb2.R - rgb1.R) * mixedAmount + rgb1.R;
            rgb1.G = (rgb2.G - rgb1.G) * mixedAmount + rgb1.G;
            rgb1.B = (rgb2.B - rgb1.B) * mixedAmount + rgb1.B;
            rgb1.A = (rgb2.A - rgb1.A) * mixedAmount + rgb1.A;

            return new TinyColor(rgb1);
        }


        //  Mix the color with pure white, from 0 to 1.
        // Providing 0 will do nothing, providing 100 will always return white.
        public TinyColor Tint(float amount = 0.1f)
        {
            return Mix(new TinyColor(Color.White), amount);
        }


        // Mix the color with pure black, from 0 to 1.
        // Providing 0 will do nothing, providing 1 will always return black.
        public TinyColor Shade(float amount = 0.1f)
        {
            return Mix(new TinyColor(Color.Black), amount);
        }


        // Desaturate the color a given amount, from 0 to 1.
        // Providing 1 is the same as calling greyscale
        public TinyColor Desaturate(float amount = 0.1f)
        {
            var hsl = ToHSL();
            hsl.S = Mathf.Clamp01(hsl.S - amount);
            return new TinyColor(hsl);
        }


        // Saturate the color a given amount, from 0 to 1.
        public TinyColor Saturate(float amount = 0.1f)
        {
            var hsl = ToHSL();
            hsl.S = Mathf.Clamp01(hsl.S + amount);
            return new TinyColor(hsl);
        }


        // Completely desaturates a color into greyscale.
        public TinyColor Greyscale()
        {
            return Desaturate(1f);
        }


        // Spin takes a positive or negative amount within [-360, 360] indicating the change of hue.
        // Values outside of this range will be wrapped into this range.
        public TinyColor Spin(float amount)
        {
            var hsl = ToHSL();
            float hue = (hsl.H + amount) % 360;
            hsl.H = hue < 0 ? 360 + hue : hue;
            return new TinyColor(hsl);
        }


        public List<TinyColor> Analogous(int results = 6, int slices = 30)
        {
            var hsl = ToHSL();
            float part = 360f / slices;
            List<TinyColor> ret = new List<TinyColor> { this };

            for (hsl.H = (hsl.H - ((part * results) / 2) + 720) % 360; results-- > 0;)
            {
                hsl.H = (hsl.H + part) % 360;
                ret.Add(new TinyColor(hsl));
            }

            return ret;
        }


        public TinyColor Complement()
        {
            var hsl = ToHSL();
            hsl.H = (hsl.H + 180) % 360f;
            return new TinyColor(hsl);
        }


        public List<TinyColor> Monochromatic(int results = 6)
        {
            var hsv = ToHSV();
            var h = hsv.H;
            var s = hsv.S;
            double v = hsv.V;
            var res = new List<TinyColor>();

            double modification = 1f / results;

            while (results-- > 0)
            {
                res.Add(new TinyColor(new HSV(h, s, (float)v)));
                v = (v + modification) % 1f;
            }

            return res;
        }


        public List<TinyColor> SplitComplement()
        {
            var hsl = ToHSL();
            var h = hsl.H;

            return new List<TinyColor>
            {
                this,
                new TinyColor( new HSL( (h + 72) % 360f, hsl.S, hsl.L)),
                new TinyColor( new HSL( (h + 216) % 360f, hsl.S, hsl.L))
            };
        }


        // Compute how the color would appear on a background
        public TinyColor OnBackground(TinyColor background)
        {
            var fg = ToRGBA();
            var bg = background;
            var alpha = fg.A + bg.A * (1 - fg.A);

            return new TinyColor(new RGBA(
                R = (fg.R * fg.A + bg.R * bg.A * (1 - fg.A)) / alpha,
                G = (fg.G * fg.A + bg.G * bg.A * (1 - fg.A)) / alpha,
                B = (fg.B * fg.A + bg.B * bg.A * (1 - fg.A)) / alpha,
                A = alpha
            ));
        }


        public List<TinyColor> Triad()
        {
            return Polyad(3);
        }


        public List<TinyColor> Tetrad()
        {
            return Polyad(4);
        }


        //  Get polyad colors, like (for 1, 2, 3, 4, 5, 6, 7, 8, etc...)
        // monad, dyad, triad, tetrad, pentad, hexad, heptad, octad, etc...
        public List<TinyColor> Polyad(int n)
        {
            var hsl = ToHSL();
            double h = hsl.H;

            var result = new List<TinyColor> { this };
            double increment = 360.0 / n;

            for (int i = 1; i < n; i++)
                result.Add(new TinyColor(new HSL((float)((h + i * increment) % 360.0), hsl.S, hsl.L)));

            return result;
        }



        #region Parse from different string representation

        public static TinyColor ParseFromName(string nameString)
        {
            if (string.IsNullOrEmpty(nameString))
                return default(TinyColor);

            nameString = nameString.Trim();

            if (Color.Colors.TryGetValue(nameString.ToLower(), out var color))
                return new TinyColor(color);

            return default(TinyColor);
        }


        public static TinyColor ParseFromHex(string hexString)
        {
            if (string.IsNullOrEmpty(hexString))
                return default(TinyColor);

            hexString = hexString.Trim();

            if (ColorUtility.TryParseHtmlString(hexString, out var color))
                return new TinyColor(color);

            return default(TinyColor);
        }


        private static List<float> GetFloats(string spaceSeparatedFloats, bool clamp01)
        {
            try
            {
                Assert.IsFalse(string.IsNullOrEmpty(spaceSeparatedFloats));
                if (string.IsNullOrEmpty(spaceSeparatedFloats))
                    return null;

                spaceSeparatedFloats = spaceSeparatedFloats.Trim();

                List<float> result = new List<float>(4);
                foreach (string s in spaceSeparatedFloats.Split(' '))
                {
                    var f = Convert.ToSingle(s);
                    if (clamp01)
                        result.Add(Mathf.Clamp01(f));
                    else
                        result.Add(f);
                }
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }


        private static List<int> GetInts(string spaceSeparatedInts, bool clamp255)
        {
            try
            {
                Assert.IsFalse(string.IsNullOrEmpty(spaceSeparatedInts));
                if (string.IsNullOrEmpty(spaceSeparatedInts))
                    return null;

                spaceSeparatedInts = spaceSeparatedInts.Trim();

                List<int> result = new List<int>(4);
                foreach (string s in spaceSeparatedInts.Split(' '))
                {
                    var f = Convert.ToInt32(s);
                    if (clamp255)
                        result.Add(Mathf.Clamp(f, 0, 255));
                    else
                        result.Add(f);
                }
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static TinyColor ParseFromRGB(string rgbString)
        {
            if (string.IsNullOrEmpty(rgbString))
                return default(TinyColor);
            var vals = GetFloats(rgbString, true);

            if (vals == null)
                return default(TinyColor);
            else if (vals.Count == 3)
                return new TinyColor(new RGB(vals[0], vals[1], vals[2]));
            else if (vals.Count == 4)
                return new TinyColor(new RGBA(vals[0], vals[1], vals[2], vals[3]));

            return default(TinyColor);
        }


        public static TinyColor ParseFromRGB256(string rgbString)
        {
            if (string.IsNullOrEmpty(rgbString))
                return default(TinyColor);
            var vals = GetInts(rgbString, true);

            if (vals == null)
                return default(TinyColor);
            if (vals.Count == 3)
                return new TinyColor(new RGB256(
                    (byte)Mathf.Clamp(vals[0], 0, 255),
                    (byte)Mathf.Clamp(vals[1], 0, 255),
                    (byte)Mathf.Clamp(vals[2], 0, 255)));
            if (vals.Count == 4)
                return new TinyColor(new RGBA256(
                    (byte)Mathf.Clamp(vals[0], 0, 255),
                    (byte)Mathf.Clamp(vals[1], 0, 255),
                    (byte)Mathf.Clamp(vals[2], 0, 255),
                    (byte)Mathf.Clamp(vals[3], 0, 255)));

            return default(TinyColor);
        }


        public static TinyColor ParseFromHSL(string hslString)
        {
            if (string.IsNullOrEmpty(hslString))
                return default(TinyColor);
            var vals = GetFloats(hslString, false);

            if (vals == null)
                return default(TinyColor);
            else if (vals.Count == 3)
                return new TinyColor(new HSL(vals[0], vals[1], vals[2]));
            else if (vals.Count == 4)
                return new TinyColor(new HSLA(vals[0], vals[1], vals[2], vals[3]));

            return default(TinyColor);
        }


        public static TinyColor ParseFromHSV(string hsvString)
        {
            if (string.IsNullOrEmpty(hsvString))
                return default(TinyColor);
            var vals = GetFloats(hsvString, false);

            if (vals == null)
                return default(TinyColor);
            else if (vals.Count == 3)
                return new TinyColor(new HSV(vals[0], vals[1], vals[2]));
            else if (vals.Count == 4)
                return new TinyColor(new HSVA(vals[0], vals[1], vals[2], vals[3]));

            return default(TinyColor);
        }

        #endregion


        #region Convert to different formats

        public override string ToString()
        {
            return ToRGBA().ToString();
        }


        public string ToName()
        {
            if (Mathf.Approximately(A, 0f))
                return "transparent";

            if (A < 1.0f)
                return null;

            var myHex8 = ToHex8String();

            foreach (var kv in Color.Colors)
            {
                var hex8 = kv.Value.ToHex8String();
                if (hex8 == myHex8)
                    return kv.Key;
            }
            return null;
        }


        public UnityEngine.Color ToColor()
        {
            return new UnityEngine.Color(R, G, B, A);
        }


        public Color32 ToColor32()
        {
            return ToColor();
        }


        public RGBA256 ToRGBA256()
        {
            return new RGBA256((byte)Mathf.RoundToInt(R * 255), (byte)Mathf.RoundToInt(G * 255), (byte)Mathf.RoundToInt(B * 255), (byte)Mathf.RoundToInt(A * 255));
        }

        public RGB256 ToRGB256()
        {
            return new RGB256((byte)Mathf.RoundToInt(R * 255), (byte)Mathf.RoundToInt(G * 255), (byte)Mathf.RoundToInt(B * 255));
        }


        public RGB ToRGB()
        {
            return new RGB(R, G, B);
        }


        public RGBA ToRGBA()
        {
            return new RGBA(R, G, B, A);
        }


        public string ToHex8String(bool cutSharpSymbol = false)
        {
            if (cutSharpSymbol)
                return ColorUtility.ToHtmlStringRGBA(ToColor());
            return "#" + ColorUtility.ToHtmlStringRGBA(ToColor());
        }


        public string ToHex6String(bool cutSharpSymbol = false)
        {
            if (cutSharpSymbol)
                return ColorUtility.ToHtmlStringRGB(ToColor());
            return "#" + ColorUtility.ToHtmlStringRGB(ToColor());
        }


        public HSL ToHSL()
        {
            return Conversion.RGBToHSL(R, G, B);
        }


        public HSLA ToHSLA()
        {
            var hsl = Conversion.RGBToHSL(R, G, B);
            return new HSLA(hsl.H, hsl.S, hsl.L, A);
        }


        public HSV ToHSV()
        {
            return Conversion.RGBToHSV(R, G, B);
        }


        public HSVA ToHSVA()
        {
            var hsv = Conversion.RGBToHSV(R, G, B);
            return new HSVA(hsv.H, hsv.S, hsv.V, A);
        }


        public int ToNumber()
        {
            var rgb = ToRGB256();
            return (rgb.R << 16) + (rgb.G << 8) + rgb.B;
        }
        #endregion
    }
}