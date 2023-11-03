using NUnit.Framework;
using Color = TinyColor.Color;

public class TinyColorConvertionsTest
{
    private class ConversionData
    {
        public string hex { get; set; }
        public string rgb { get; set; }
        public string hex8 { get; set; }
        public string hsl { get; set; }
        public string hsv { get; set; }
    }

    private ConversionData[] conversions;

    [SetUp]
    public void Setup()
    {
        // Initialize the conversions array with data before each test
        conversions = new ConversionData[]
        {
            new ConversionData { hex = "#FFFFFF", rgb = "rgb(100.0%, 100.0%, 100.0%)", hex8 = "#FFFFFFFF", hsl = "hsl(0, 0.000, 1.000)", hsv = "hsv(0, 0.000, 1.000)" },
            new ConversionData { hex = "#808080", rgb = "rgb(050.0%, 050.0%, 050.0%)", hex8 = "#808080FF", hsl = "hsl(0, 0.000, 0.500)", hsv = "hsv(0, 0.000, 0.500)" },
            new ConversionData { hex = "#000000", rgb = "rgb(000.0%, 000.0%, 000.0%)", hex8 = "#000000FF", hsl = "hsl(0, 0.000, 0.000)", hsv = "hsv(0, 0.000, 0.000)" },
            new ConversionData { hex = "#FF0000", rgb = "rgb(100.0%, 000.0%, 000.0%)", hex8 = "#FF0000FF", hsl = "hsl(0.0, 1.000, 0.500)", hsv = "hsv(0.0, 1.000, 1.000)" },
            new ConversionData { hex = "#BFBF00", rgb = "rgb(075.0%, 075.0%, 000.0%)", hex8 = "#BFBF00FF", hsl = "hsl(60.0, 1.000, 0.375)", hsv = "hsv(60.0, 1.000, 0.750)" },
            new ConversionData { hex = "#008000", rgb = "rgb(000.0%, 050.0%, 000.0%)", hex8 = "#008000FF", hsl = "hsl(120.0, 1.000, 0.250)", hsv = "hsv(120.0, 1.000, 0.500)" },
            new ConversionData { hex = "#80FFFF", rgb = "rgb(050.0%, 100.0%, 100.0%)", hex8 = "#80FFFFFF", hsl = "hsl(180.0, 1.000, 0.750)", hsv = "hsv(180.0, 0.500, 1.000)" },
            new ConversionData { hex = "#8080FF", rgb = "rgb(050.0%, 050.0%, 100.0%)", hex8 = "#8080FFFF", hsl = "hsl(240.0, 1.000, 0.750)", hsv = "hsv(240.0, 0.500, 1.000)" },
            new ConversionData { hex = "#BF40BF", rgb = "rgb(075.0%, 025.0%, 075.0%)", hex8 = "#BF40BFFF", hsl = "hsl(300.0, 0.500, 0.500)", hsv = "hsv(300.0, 0.667, 0.750)" },
            new ConversionData { hex = "#A0A424", rgb = "rgb(062.8%, 064.3%, 014.2%)", hex8 = "#A0A424FF", hsl = "hsl(61.8, 0.638, 0.393)", hsv = "hsv(61.8, 0.779, 0.643)" },
            new ConversionData { hex = "#1EAC41", rgb = "rgb(011.6%, 067.5%, 025.5%)", hex8 = "#1EAC41FF", hsl = "hsl(134.9, 0.707, 0.396)", hsv = "hsv(134.9, 0.828, 0.675)" },
            new ConversionData { hex = "#B430E5", rgb = "rgb(070.4%, 018.7%, 089.7%)", hex8 = "#B430E5FF", hsl = "hsl(283.7, 0.775, 0.542)", hsv = "hsv(283.7, 0.792, 0.897)" },
            new ConversionData { hex = "#FEF888", rgb = "rgb(099.8%, 097.4%, 053.2%)", hex8 = "#FEF888FF", hsl = "hsl(56.9, 0.991, 0.765)", hsv = "hsv(56.9, 0.467, 0.998)" },
            new ConversionData { hex = "#19CB97", rgb = "rgb(009.9%, 079.5%, 059.1%)", hex8 = "#19CB97FF", hsl = "hsl(162.4, 0.779, 0.447)", hsv = "hsv(162.4, 0.875, 0.795)" },
            new ConversionData { hex = "#362698", rgb = "rgb(021.1%, 014.9%, 059.7%)", hex8 = "#362698FF", hsl = "hsl(248.3, 0.601, 0.373)", hsv = "hsv(248.3, 0.750, 0.597)" },
            new ConversionData { hex = "#7E7EB8", rgb = "rgb(049.5%, 049.3%, 072.1%)", hex8 = "#7E7EB8FF", hsl = "hsl(240.5, 0.290, 0.607)", hsv = "hsv(240.5, 0.316, 0.721)" }
        };
    }


    //[Test]
    //public void ShouldHaveColorEquality()
    //{
    //    Assert.AreEqual(16, conversions.Length);

    //    foreach (var c in conversions)
    //    {
    //        Color color = TinyColorToColor(new TinyColor(c.hex));

    //        Assert.IsTrue(new TinyColor(c.rgb).IsValid);
    //        Assert.IsTrue(AreColorsEqual(new TinyColor(c.rgb), color));
    //        Assert.IsTrue(AreColorsEqual(new TinyColor(c.rgb), new TinyColor(c.hex8)));
    //        Assert.IsTrue(AreColorsEqual(new TinyColor(c.rgb), new TinyColor(c.hsl)));
    //        Assert.IsTrue(AreColorsEqual(new TinyColor(c.rgb), new TinyColor(c.hsv)));
    //        Assert.IsTrue(AreColorsEqual(new TinyColor(c.rgb), new TinyColor(c.rgb)));
    //        Assert.IsTrue(AreColorsEqual(new TinyColor(c.hex), new TinyColor(c.hex)));
    //        Assert.IsTrue(AreColorsEqual(new TinyColor(c.hex), new TinyColor(c.hex8)));
    //        Assert.IsTrue(AreColorsEqual(new TinyColor(c.hex), new TinyColor(c.hsl)));
    //        Assert.IsTrue(AreColorsEqual(new TinyColor(c.hex), new TinyColor(c.hsv)));
    //        Assert.IsTrue(AreColorsEqual(new TinyColor(c.hsl), new TinyColor(c.hsv)));
    //    }
    //}
}
