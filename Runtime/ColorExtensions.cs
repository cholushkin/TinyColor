using System.Collections.Generic;
using TinyColorLib;
using Color = UnityEngine.Color;

public static class ColorExtensions
{
    // 🎨 Expressive chaining for fluent color styling
    // Example: var adjusted = baseColor.Darken(0.2f).Desaturated(0.1f).Lighten(0.3f);

    // 🌑 Darken the color by a percentage
    public static Color Darken(this Color color, float factor = 0.3f)
        => new TinyColor(color).Darken(factor).ToColor();

    // ☀️ Lighten the color by a percentage
    public static Color Lighten(this Color color, float factor = 0.3f)
        => new TinyColor(color).Lighten(factor).ToColor();

    // 🧊 Reduce the saturation (more grayscale)
    public static Color Desaturated(this Color color, float factor = 0.3f)
        => new TinyColor(color).Desaturate(factor).ToColor();

    // 🌈 Boost the saturation (more vivid)
    public static Color Saturated(this Color color, float factor = 0.3f)
        => new TinyColor(color).Saturate(factor).ToColor();

    // 🎚️ Convert to grayscale using luminosity method
    public static Color Greyscale(this Color color)
        => new TinyColor(color).Greyscale().ToColor();

    // 🎨 Apply a tint (blend with white)
    public static Color Tint(this Color color, float factor = 0.3f)
        => new TinyColor(color).Tint(factor).ToColor();

    // 🕶️ Apply a shade (blend with black)
    public static Color Shade(this Color color, float factor = 0.3f)
        => new TinyColor(color).Shade(factor).ToColor();

    // 🔄 Rotate the hue around the color wheel
    public static Color Spin(this Color color, float degrees)
        => new TinyColor(color).Spin(degrees).ToColor();

    // 🧭 Complementary color
    public static Color Complement(this Color color)
        => new TinyColor(color).Complement().ToColor();

    // 🎭 Blend this color on top of a background
    public static Color OnBackground(this Color fg, Color bg)
        => new TinyColor(fg).OnBackground(new TinyColor(bg)).ToColor();

    // 🧪 Mix two colors with a given weight
    public static Color Mix(this Color color, Color other, float factor = 0.5f)
        => new TinyColor(color).Mix(new TinyColor(other), factor).ToColor();

    // 🎨 Color harmony - Analogous colors
    public static Color[] Analogous(this Color color)
        => new TinyColor(color).Analogous().ConvertAll(c => c.ToColor()).ToArray();

    // 🎨 Color harmony - Triadic colors
    public static Color[] Triad(this Color color)
        => new TinyColor(color).Triad().ConvertAll(c => c.ToColor()).ToArray();

    // 🎨 Color harmony - Tetradic colors
    public static Color[] Tetrad(this Color color)
        => new TinyColor(color).Tetrad().ConvertAll(c => c.ToColor()).ToArray();

    // 🎨 Color harmony - Split complement
    public static Color[] SplitComplement(this Color color)
        => new TinyColor(color).SplitComplement().ConvertAll(c => c.ToColor()).ToArray();

    // 🎨 Color harmony - Monochromatic variations
    public static Color[] Monochromatic(this Color color)
        => new TinyColor(color).Monochromatic().ConvertAll(c => c.ToColor()).ToArray();

    // 🌓 Check if color is considered light
    public static bool IsLight(this Color color)
        => new TinyColor(color).IsLight();

    // 🌑 Check if color is considered dark
    public static bool IsDark(this Color color)
        => new TinyColor(color).IsDark();

    // 📏 Contrast ratio between two colors
    public static float ContrastWith(this Color color, Color other)
        => ReadabilityHelpers.Readability(new TinyColor(color), new TinyColor(other));

    // ✅ WCAG contrast readability check
    public static bool IsReadableOn(this Color color, Color background,
        ReadabilityHelpers.WCAGLevel level = ReadabilityHelpers.WCAGLevel.AA,
        ReadabilityHelpers.WCAGSize size = ReadabilityHelpers.WCAGSize.Small)
        => ReadabilityHelpers.IsReadable(new TinyColor(background), new TinyColor(color), level, size);

    // 🔍 Get most readable color from a list against a background
    public static Color MostReadableOn(this Color background, Color[] candidates,
        bool includeFallback = true,
        ReadabilityHelpers.WCAGLevel level = ReadabilityHelpers.WCAGLevel.AA,
        ReadabilityHelpers.WCAGSize size = ReadabilityHelpers.WCAGSize.Small)
        => ReadabilityHelpers.MostReadable(
            new TinyColor(background),
            new List<TinyColor>(System.Array.ConvertAll(candidates, c => new TinyColor(c))),
            includeFallback, level, size).ToColor();
}
