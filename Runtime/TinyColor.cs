using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace TinyColor
{
    public class TinyColor
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

            public override string ToString()
            {
                return $"RGB({R} {G} {B})";
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

            public override string ToString()
            {
                return $"RGBA({R} {G} {B} {A})";
            }
        }

        public class RGBA256
        {
            public byte R;
            public byte G;
            public byte B;
            public byte A;

            public RGBA256(byte r, byte g, byte b, byte a)
            {
                R = r;
                G = g;
                B = b;
                A = a;
            }

            public override string ToString()
            {
                return $"RGBA256({R} {G} {B} {A})";
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

            public override string ToString()
            {
                return $"HSL({H} {S} {L})";
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

            public override string ToString()
            {
                return $"HSLA({H} {S} {L} {A})";
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

            public override string ToString()
            {
                return $"HSV({H} {S} {V})";
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

            public override string ToString()
            {
                return $"HSVA({H} {S} {V} {A})";
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

        public TinyColor(HSL colorHSL):
            this(Conversion.HslToRgb(colorHSL.H, colorHSL.S, colorHSL.L))
        {
        }

        public TinyColor(HSLA colorHSLA)
        {
        }

        public TinyColor(HSV colorHSV):
            this(Conversion.HSVToRGB(colorHSV.H, colorHSV.S, colorHSV.V))
        {
        }

        public TinyColor(HSVA colorHSVA)
        {
        }
        #endregion



        public override string ToString()
        {
            return $"RGBA({R} {G} {B} {A})";
        }


        public string ToRGBA256String()
        {
            var rgba256 = this.ToRGBA256();
            return $"RGBA({rgba256.R}, {rgba256.G}, {rgba256.B}, {rgba256.A})";
        }


        public bool Equals(TinyColor other)
        {
            var a = ToRGBA256();
            var b = other.ToRGBA256();
            return a.R.Equals(b.R) && a.G.Equals(b.G) && a.B.Equals(b.B) && a.A.Equals(b.A);
        }


        // Possible string inputs:
        // "red"
        // "#ff000000" or "ff000000"
        // "1.0 0 0"
        // "1.0, 0, 0, 1"

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
            Assert.IsFalse(string.IsNullOrEmpty(spaceSeparatedFloats));
            if (string.IsNullOrEmpty(spaceSeparatedFloats))
                return null;

            spaceSeparatedFloats = spaceSeparatedFloats.Trim();

            List<float> result = new List<float>(4);
            foreach (string s in spaceSeparatedFloats.Split(' '))
            {
                var f = Convert.ToSingle(s);
                if(clamp01)
                    result.Add(Mathf.Clamp01(f));
                else
                    result.Add(f);
            }
            return result;
        }


        public static TinyColor ParseFromRGB(string rgbString)
        {
            if (string.IsNullOrEmpty(rgbString))
                return default(TinyColor);
            var vals = GetFloats(rgbString, true);

            if (vals.Count == 3)
                return new TinyColor(new RGB(vals[0], vals[1], vals[2]));
            else if (vals.Count == 4)
                return new TinyColor(new RGBA(vals[0], vals[1], vals[2], vals[3]));

            return default(TinyColor);
        }


        public static TinyColor ParseFromHSL(string hslString)
        {
            if (string.IsNullOrEmpty(hslString))
                return default(TinyColor);
            var vals = GetFloats(hslString, false);

            if (vals.Count == 3)
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

            if (vals.Count == 3)
                return new TinyColor(new HSV(vals[0], vals[1], vals[2]));
            else if (vals.Count == 4)
                return new TinyColor(new HSVA(vals[0], vals[1], vals[2], vals[3]));

            return default(TinyColor);
        }


        #region Convert to different color formats
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

        public string ToHex8String()
        {
            return "#" + ColorUtility.ToHtmlStringRGBA(ToColor());
        }

        public string ToHex6String()
        {
            return "#" + ColorUtility.ToHtmlStringRGB(ToColor());
        }

        public HSL ToHSL()
        {
            return Conversion.RGBToHSL(R, G, B);
        }
        #endregion

    }
}