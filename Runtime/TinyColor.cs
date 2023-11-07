using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace TinyColor
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

        public TinyColor(string colorName) :
            this(Color.Colors.GetValueOrDefault(colorName.ToLower()))
        {
        }


        #endregion


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


        public RGB ToRGBA()
        {
            return new RGBA(R, G, B, A);
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


        public HSLA ToHSLA()
        {
            var hsl = Conversion.RGBToHSL(R, G, B);
            return new HSLA(hsl.H, hsl.S, hsl.L, A);
        }


        public HSV ToHSV()
        {
            return Conversion.RGBToHSV(R, G, B);
        }
        #endregion
    }
}