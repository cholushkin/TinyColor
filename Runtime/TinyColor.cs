using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TinyColor
{
    public class TinyColor
    {
        public class RGB { public float R, G, B; }
        public class RGBA : RGB { public float A; }
        public class HSL { public float H, S, L; }
        public class HSLA : HSL { public float A; }
        public class HSV { public float H, S, V; }
        public class HSVA : HSV { public float A; }


        public float R;
        public float G;
        public float B;
        public float A;


        #region Constructors
        public TinyColor(UnityEngine.Color color)
        {
        }

        public TinyColor(UnityEngine.Color32 color32)
        {
        }

        public TinyColor(int color32)
        {
        }

        public TinyColor(RGB colorRGB)
        {
        }

        public TinyColor(RGBA colorRGBA)
        {
        }

        public TinyColor(HSL colorHSL)
        {
        }

        public TinyColor(HSLA colorHSLA)
        {
        }

        public TinyColor(HSV colorHSV)
        {
        }

        public TinyColor(HSVA colorHSVA)
        {
        }
        #endregion


        // Possible string inputs:
        // "red"
        // "#f00" or "f00"
        // "#ff0000" or "ff0000"
        // "#ff000000" or "ff000000"
        // "rgb 255 0 0" or "rgb (255, 0, 0)"
        // "rgb 1.0 0 0" or "rgb (1, 0, 0)"
        // "rgba (255, 0, 0, 1)" or "rgba 255, 0, 0, 1"
        // "rgba (1.0, 0, 0, 1)" or "rgba 1.0, 0, 0, 1"
        // "hsl(0, 100%, 50%)" or "hsl 0 100% 50%"
        // "hsla(0, 100%, 50%, 1)" or "hsla 0 100% 50%, 1"
        // "hsv(0, 100%, 100%)" or "hsv 0 100% 100%"

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


        private static List<float> GetFloats(string spaceSeparatedFloats)
        {
            if (string.IsNullOrEmpty(spaceSeparatedFloats))
                return null;

            spaceSeparatedFloats = spaceSeparatedFloats.Trim();

            List<float> result = new List<float>(4);
            foreach (string s in spaceSeparatedFloats.Split(' '))
            {
                var f = Convert.ToSingle(s);
                result.Add(Mathf.Clamp01(f));
            }
            return result;
        }

        //public static TinyColor ParseFromRGB(string rgbString)
        //{
        //    if (string.IsNullOrEmpty(rgbString))
        //        return default(TinyColor);

           


        //        return default(TinyColor);
        //}

        //public static TinyColor ParseFromHSLV(string hslvString)
        //{
        //    if (string.IsNullOrEmpty(hslvString))
        //        return default(TinyColor);
        //    return default(TinyColor);
        //}


        #region Convert to different color formats
        UnityEngine.Color ToColor() { return UnityEngine.Color.white; }
        UnityEngine.Color32 ToColor32() { return UnityEngine.Color.white; }
        #endregion

    }
}