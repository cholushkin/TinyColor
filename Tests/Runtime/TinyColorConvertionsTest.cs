using NUnit.Framework;
using UnityEngine;

namespace TinyColor
{
    public class TinyColorConvertionsTest
    {
        private class ConversionData
        {
            public string hex6 { get; set; }
            public string rgb { get; set; }
            public string hex8 { get; set; }
            public string hsl { get; set; }
            public string hsv { get; set; }
        }

        private ConversionData[] _conversions;

        [SetUp]
        public void Setup()
        {
            // Initialize the conversions array with test data before each test
            _conversions = new ConversionData[]
            {
                new ConversionData { hex6 = "#FFFFFF", rgb = "1.0 1.0 1.0",       hex8 = "#FFFFFFFF", hsl = "0 0.000 1.000",     hsv = "0 0.000 1.000" },
                new ConversionData { hex6 = "#808080", rgb = "0.5 0.5 0.5",       hex8 = "#808080FF", hsl = "0 0.000 0.500",     hsv = "0 0.000 0.500" },
                new ConversionData { hex6 = "#000000", rgb = "0.0 0.0 0.0",       hex8 = "#000000FF", hsl = "0 0.000 0.000",     hsv = "0 0.000 0.000" },
                new ConversionData { hex6 = "#FF0000", rgb = "1.0 0.0 0.0",       hex8 = "#FF0000FF", hsl = "0.0 1.000 0.500",   hsv = "0.0 1.000 1.000" },
                new ConversionData { hex6 = "#BFBF00", rgb = "0.75 0.75 0.0",     hex8 = "#BFBF00FF", hsl = "60.0 1.000 0.375",  hsv = "60.0 1.000 0.750" },
                new ConversionData { hex6 = "#008000", rgb = "0.0 0.5 0.0",       hex8 = "#008000FF", hsl = "120.0 1.000 0.250", hsv = "120.0 1.000 0.500" },
                new ConversionData { hex6 = "#80FFFF", rgb = "0.5 1.0 1.0",       hex8 = "#80FFFFFF", hsl = "180.0 1.000 0.750", hsv = "180.0 0.500 1.000" },
                new ConversionData { hex6 = "#8080FF", rgb = "0.5 0.5 1.0",       hex8 = "#8080FFFF", hsl = "240.0 1.000 0.750", hsv = "240.0 0.500 1.000" },
                new ConversionData { hex6 = "#BF40BF", rgb = "0.75 0.25 0.75",    hex8 = "#BF40BFFF", hsl = "300.0 0.500 0.500", hsv = "300.0 0.667 0.750" },
                new ConversionData { hex6 = "#A0A424", rgb = "0.628 0.643 0.142", hex8 = "#A0A424FF", hsl = "61.8 0.638 0.393",  hsv = "61.8 0.779 0.643" },
                new ConversionData { hex6 = "#1EAC41", rgb = "0.116 0.675 0.255", hex8 = "#1EAC41FF", hsl = "134.9 0.707 0.396", hsv = "134.9 0.828 0.675" },
                new ConversionData { hex6 = "#B430E5", rgb = "0.704 0.187 0.897", hex8 = "#B430E5FF", hsl = "283.7 0.775 0.542", hsv = "283.7 0.792 0.897" },
                new ConversionData { hex6 = "#FEF888", rgb = "0.998 0.974 0.532", hex8 = "#FEF888FF", hsl = "56.9 0.991 0.765",  hsv = "56.9 0.467 0.998" },
                new ConversionData { hex6 = "#19CB97", rgb = "0.099 0.795 0.591", hex8 = "#19CB97FF", hsl = "162.4 0.779 0.447", hsv = "162.4 0.875 0.795" },
                new ConversionData { hex6 = "#362698", rgb = "0.211 0.149 0.597", hex8 = "#362698FF", hsl = "248.3 0.601 0.373", hsv = "248.3 0.750 0.597" },
                new ConversionData { hex6 = "#7E7EB8", rgb = "0.495 0.493 0.721", hex8 = "#7E7EB8FF", hsl = "240.5 0.290 0.607", hsv = "240.5 0.316 0.721" }
            };
        }


        [Test]
        public void ShouldHaveColorEquality()
        {
            foreach (var c in _conversions)
            {
                Assert.IsTrue(TinyColor.ParseFromHex(c.hex6).Equals(TinyColor.ParseFromRGB(c.rgb)), $"Parsing from HEX6({TinyColor.ParseFromHex(c.hex6)}) VS RGB({TinyColor.ParseFromRGB(c.rgb)})");
                Assert.IsTrue(TinyColor.ParseFromHex(c.hex8).Equals(TinyColor.ParseFromRGB(c.rgb)), $"Parsing from HEX8({TinyColor.ParseFromHex(c.hex8)}) VS RGB({TinyColor.ParseFromRGB(c.rgb)})");
                Assert.IsTrue(TinyColor.ParseFromHSL(c.hsl).Equals(TinyColor.ParseFromRGB(c.rgb)), $"Parsing from HSL({TinyColor.ParseFromHSL(c.hsl)}) VS RGB({TinyColor.ParseFromRGB(c.rgb)})");
                Assert.IsTrue(TinyColor.ParseFromHSV(c.hsv).Equals(TinyColor.ParseFromRGB(c.rgb)), $"Parsing from HSV({TinyColor.ParseFromHSV(c.hsv)}) VS RGB({TinyColor.ParseFromRGB(c.rgb)})");
                Assert.IsTrue(TinyColor.ParseFromRGB(c.rgb).Equals(TinyColor.ParseFromRGB(c.rgb)), $"Parsing from RGB({TinyColor.ParseFromRGB(c.rgb)}) VS RGB({TinyColor.ParseFromRGB(c.rgb)})");
                Assert.IsTrue(TinyColor.ParseFromHex(c.hex6).Equals(TinyColor.ParseFromHex(c.hex6)), $"Parsing from HEX6({TinyColor.ParseFromHex(c.hex6)}) VS HEX6({TinyColor.ParseFromHex(c.hex6)})");
                Assert.IsTrue(TinyColor.ParseFromHex(c.hex6).Equals(TinyColor.ParseFromHex(c.hex8)), $"Parsing from HEX6({TinyColor.ParseFromHex(c.hex6)}) VS HEX8({TinyColor.ParseFromHex(c.hex8)})");
                Assert.IsTrue(TinyColor.ParseFromHex(c.hex6).Equals(TinyColor.ParseFromHSL(c.hsl)), $"Parsing from HEX6({TinyColor.ParseFromHex(c.hex6)}) VS HSL({TinyColor.ParseFromHSL(c.hsl)})");
                Assert.IsTrue(TinyColor.ParseFromHex(c.hex6).Equals(TinyColor.ParseFromHSV(c.hsv)), $"Parsing from HEX6({TinyColor.ParseFromHex(c.hex6)}) VS HSV({TinyColor.ParseFromHSV(c.hsv)})");
                Assert.IsTrue(TinyColor.ParseFromHSL(c.hsl).Equals(TinyColor.ParseFromHSV(c.hsv)), $"Parsing from HSL({TinyColor.ParseFromHSL(c.hsl)}) VS HSV({TinyColor.ParseFromHSV(c.hsv)})");
            }
        }


        [Test]
        public void HSLObject()
        {
            foreach (var c in _conversions)
            {
                TinyColor tiny = TinyColor.ParseFromHex(c.hex6);
                Assert.AreEqual(tiny.ToHex8String(), new TinyColor(tiny.ToHSL()).ToHex8String());
            }
        }


        [Test]
        public void HSLString()
        {
            foreach (var c in _conversions)
            {
                TinyColor tiny = TinyColor.ParseFromHex(c.hex6);
                var input = tiny.ToRGBA256();

                var output = TinyColor.ParseFromHSL(tiny.ToHSL().ToString()).ToRGBA256();
                var maxDiff = 0;

                Assert.IsTrue(Mathf.Abs(input.R - output.R) <= maxDiff); // Check Red value difference
                Assert.IsTrue(Mathf.Abs(input.G - output.G) <= maxDiff); // Check Green value difference
                Assert.IsTrue(Mathf.Abs(input.B - output.B) <= maxDiff); // Check Blue value difference
            }
        }


        [Test]
        public void HSVObject()
        {
            foreach (var c in _conversions)
            {
                TinyColor tiny = TinyColor.ParseFromHSV( c.hsv );
                Assert.AreEqual(tiny.ToHex8String(), new TinyColor(tiny.ToHSV()).ToHex8String());
            }
        }


        [Test]
        public void HSVString()
        {
            foreach (var c in _conversions) 
            {
                TinyColor tiny = TinyColor.ParseFromHex(c.hex6);
                var input = tiny.ToRGBA256();

                var output = TinyColor.ParseFromHSV(tiny.ToHSV().ToString()).ToRGBA256();
                var maxDiff = 0;
                
                Assert.IsTrue(Mathf.Abs(input.R - output.R) <= maxDiff); // Check Red value difference
                Assert.IsTrue(Mathf.Abs(input.G - output.G) <= maxDiff); // Check Green value difference
                Assert.IsTrue(Mathf.Abs(input.B - output.B) <= maxDiff); // Check Blue value difference
            }
        }


        [Test]
        public void RGBObject()
        {
            foreach (var c in _conversions)
            {
                TinyColor tiny = TinyColor.ParseFromHex(c.hex6);
                Assert.AreEqual(tiny.ToHex8String(), new TinyColor ( tiny.ToRGB() ).ToHex8String());
            }
        }


        [Test]
        public void RgbString()
        {
            foreach (var c in _conversions)
            {
                TinyColor tiny = TinyColor.ParseFromHex(c.hex6);
                Assert.AreEqual(tiny.ToHex8String(), TinyColor.ParseFromRGB(tiny.ToRGB().ToString()).ToHex8String());
            }
        }

        [Test]
        public void TestObject()
        {
            foreach (var c in _conversions)
            {
                TinyColor tiny = TinyColor.ParseFromHex(c.hex6);
                Assert.AreEqual(tiny.ToHex8String(), new TinyColor(tiny).ToHex8String());
            }
        }
    }
}