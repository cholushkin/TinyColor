using System.Collections.Generic;
using UnityEngine;

namespace TinyColorLib
{
    public static class ReadabilityHelpers
    {
        public enum WCAGLevel
        {
            AA,
            AAA
        }

        public enum WCAGSize
        {
            Small,
            Large
        }

        // Analyze the 2 colors and returns the color contrast defined by (WCAG Version 2)
        public static float Readability(TinyColor color1, TinyColor color2)
        {
            return (Mathf.Max(color1.GetLuminance(), color2.GetLuminance()) + 0.05f) /
                   (Mathf.Min(color1.GetLuminance(), color2.GetLuminance()) + 0.05f);
        }

        // Ensure that foreground and background color combinations meet WCAG2 guidelines.
        // The third argument is an object.
        //      the 'level' property states 'AA' or 'AAA' - if missing or invalid, it defaults to 'AA';
        //      the 'size' property states 'large' or 'small' - if missing or invalid, it defaults to 'small'.
        // If the entire object is absent, isReadable defaults to {level:"AA",size:"small"}.
        // 
        // Example:
        // new TinyColor().IsReadable("#000", "#111") => false
        // new TinyColor().IsReadable("#000", "#111", { level: 'AA', size: 'large' }) => false
        public static bool IsReadable(TinyColor color1, TinyColor color2, WCAGLevel level = WCAGLevel.AA, WCAGSize size = WCAGSize.Small)
        {
            var readabilityLevel = Readability(color1, color2);

            switch ((level, size))
            {
                case (WCAGLevel.AA, WCAGSize.Small):
                case (WCAGLevel.AAA, WCAGSize.Large):
                    return readabilityLevel >= 4.5f;
                case (WCAGLevel.AA, WCAGSize.Large):
                    return readabilityLevel >= 3f;
                case (WCAGLevel.AAA, WCAGSize.Small):
                    return readabilityLevel >= 7f;
                default:
                    return false;
            }
        }


        //  Given a base color and a list of possible foreground or background
        //  colors for that base, returns the most readable color.
        //  Optionally returns Black or White if the most readable color is unreadable.
        // 
        //  @param baseColor - the base color.
        //  @param colorList - array of colors to pick the most readable one from.
        //  @param args - and object with extra arguments
        // 
        //  Example
        //  new TinyColor().mostReadable('#123', ['#124", "#125'], { includeFallbackColors: false }).toHexString(); // "#112255"
        //  new TinyColor().mostReadable('#123', ['#124", "#125'],{ includeFallbackColors: true }).toHexString();  // "#ffffff"
        //  new TinyColor().mostReadable('#a8015a', ["#faf3f3"], { includeFallbackColors: true, level: 'AAA', size: 'large' }).toHexString(); // "#faf3f3"
        //  new TinyColor().mostReadable('#a8015a', ["#faf3f3"], { includeFallbackColors: true, level: 'AAA', size: 'small' }).toHexString(); // "#ffffff"
        public static TinyColor MostReadable(TinyColor baseColor, List<TinyColor> colorList, bool includeFallbackColors = false, WCAGLevel level = WCAGLevel.AA, WCAGSize size = WCAGSize.Small)
        {
            TinyColor bestColor = null;
            var bestScore = 0f;

            foreach (var color in colorList)
            {
                var score = Readability(baseColor, color);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestColor = color;
                }
            }

            if (IsReadable(baseColor, bestColor, level, size) || !includeFallbackColors)
            {
                return bestColor;
            }

            includeFallbackColors = false;
            return MostReadable(baseColor, new List<TinyColor> { TinyColor.ParseFromHex("#fff"), TinyColor.ParseFromHex("#000") }, includeFallbackColors, level, size);
        }
    }
}