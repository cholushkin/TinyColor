using UnityEngine;

namespace TinyColor
{
    public static class ColorUtils
    {
        // Take input from [0, n] and return it as [0, 1]
        public static float Bound01(float n, float max)
        {
            if (IsOnePointZero(n))
            {
                n = 1.0f;
            }

            bool isPercent = IsPercentage(n);
            n = max == 360f ? n : Mathf.Clamp(n, 0f, max);

            if (isPercent)
            {
                n = (int)(n * max) / 100f;
            }

            if (Mathf.Abs(n - max) < 0.000001f)
            {
                return 1.0f;
            }

            if (max == 360f)
            {
                n = (n < 0f ? (n % max) + max : n % max) / max;
            }
            else
            {
                n = (n % max) / max;
            }

            return n;
        }

        public static float Clamp01(float val)
        {
            return Mathf.Clamp01(val);
        }

        // Check if a number is 1.0
        private static bool IsOnePointZero(float n)
        {
            return n.ToString().Contains(".") && n == 1.0f;
        }

        // Check if the number is a percentage
        private static bool IsPercentage(float n)
        {
            return n.ToString().Contains("%");
        }

        // Return a valid alpha value [0,1] with all invalid values being set to 1
        public static float BoundAlpha(float a)
        {
            if (float.IsNaN(a) || a < 0 || a > 1)
            {
                a = 1;
            }

            return a;
        }

        // Replace a decimal with its percentage value
        public static object ConvertToPercentage(float n)
        {
            if (n <= 1)
            {
                return n * 100f + "%";
            }

            return n;
        }

        // Force a hex value to have 2 characters
        public static string Pad2(string c)
        {
            return c.Length == 1 ? "0" + c : c;
        }
    }

}