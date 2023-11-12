using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace TinyColor
{
    public class TinyColorModificationsTest
    {
        #region Test data

        private static readonly string[] DESATURATIONS =
        {
            "#FF0000", "#FE0101", "#FC0303", "#FB0404", "#FA0505", "#F90606", "#F70808", "#F60909", "#F50A0A", "#F40B0B",
            "#F20D0D", "#F10E0E", "#F00F0F", "#EE1111", "#ED1212", "#EC1313", "#EB1414", "#E91616", "#E81717", "#E71818",
            "#E61A1A", "#E41B1B", "#E31C1C", "#E21D1D", "#E01F1F", "#DF2020", "#DE2121", "#DD2222", "#DB2424", "#DA2525",
            "#D92626", "#D72828", "#D62929", "#D52A2A", "#D42B2B", "#D22D2D", "#D12E2E", "#D02F2F", "#CF3030", "#CD3232",
            "#CC3333", "#CB3434", "#C93636", "#C83737", "#C73838", "#C63939", "#C43B3B", "#C33C3C", "#C23D3D", "#C13E3E",
            "#BF4040", "#BE4141", "#BD4242", "#BB4444", "#BA4545", "#B94646", "#B84747", "#B64949", "#B54A4A", "#B44B4B",
            "#B24C4D", "#B14E4E", "#B04F4F", "#AF5050", "#AD5252", "#AC5353", "#AB5454", "#AA5555", "#A85757", "#A75858",
            "#A65959", "#A45B5B", "#A35C5C", "#A25D5D", "#A15E5E", "#9F6060", "#9E6161", "#9D6262", "#9C6363", "#9A6565",
            "#996666", "#986767", "#966969", "#956A6A", "#946B6B", "#936C6C", "#916E6E", "#906F6F", "#8F7070", "#8E7171",
            "#8C7373", "#8B7474", "#8A7575", "#887777", "#877878", "#867979", "#857A7A", "#837C7C", "#827D7D", "#817E7E",
            "#808080"
        };

        private static readonly string[] SATURATIONS =
        {
            "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000",
            "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000",
            "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000",
            "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000",
            "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000",
            "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000",
            "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000",
            "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000",
            "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000",
            "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000",
            "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000", "#FF0000"
        };

        private static readonly string[] LIGHTENS =
        {
            "#FF0000", "#FF0505", "#FF0A0A", "#FF0F0F", "#FF1414", "#FF1A1A", "#FF1F1F", "#FF2424",
            "#FF2929", "#FF2E2E", "#FF3333", "#FF3838", "#FF3D3D", "#FF4242", "#FF4747", "#FF4C4D",
            "#FF5252", "#FF5757", "#FF5C5C", "#FF6161", "#FF6666", "#FF6B6B", "#FF7070", "#FF7575",
            "#FF7A7A", "#FF8080", "#FF8585", "#FF8A8A", "#FF8F8F", "#FF9494", "#FF9999", "#FF9E9E",
            "#FFA3A3", "#FFA8A8", "#FFADAD", "#FFB3B3", "#FFB8B8", "#FFBDBD", "#FFC2C2", "#FFC7C7",
            "#FFCCCC", "#FFD1D1", "#FFD6D6", "#FFDBDB", "#FFE0E0", "#FFE6E6", "#FFEBEB", "#FFF0F0",
            "#FFF5F5", "#FFFAFA", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF",
            "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF",
            "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF",
            "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF",
            "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF",
            "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF",
            "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF", "#FFFFFF"
        };

        private static readonly string[] BRIGHTENS =
        {
            "#FF0000", "#FF0303", "#FF0505", "#FF0808", "#FF0A0A", "#FF0D0D", "#FF0F0F", "#FF1212",
            "#FF1414", "#FF1717", "#FF1A1A", "#FF1C1C", "#FF1F1F", "#FF2121", "#FF2424", "#FF2626",
            "#FF2929", "#FF2B2B", "#FF2E2E", "#FF3030", "#FF3333", "#FF3636", "#FF3838", "#FF3B3B",
            "#FF3D3D", "#FF4040", "#FF4242", "#FF4545", "#FF4747", "#FF4A4A", "#FF4C4C", "#FF4F4F",
            "#FF5252", "#FF5454", "#FF5757", "#FF5959", "#FF5C5C", "#FF5E5E", "#FF6161", "#FF6363",
            "#FF6666", "#FF6969", "#FF6B6B", "#FF6E6E", "#FF7070", "#FF7373", "#FF7575", "#FF7878",
            "#FF7A7A", "#FF7D7D", "#FF8080", "#FF8282", "#FF8585", "#FF8787", "#FF8A8A", "#FF8C8C",
            "#FF8F8F", "#FF9191", "#FF9494", "#FF9696", "#FF9999", "#FF9C9C", "#FF9E9E", "#FFA1A1",
            "#FFA3A3", "#FFA6A6", "#FFA8A8", "#FFABAB", "#FFADAD", "#FFB0B0", "#FFB2B2", "#FFB5B5",
            "#FFB8B8", "#FFBABA", "#FFBDBD", "#FFBFBF", "#FFC2C2", "#FFC4C4", "#FFC7C7", "#FFC9C9",
            "#FFCCCC", "#FFCFCF", "#FFD1D1", "#FFD4D4", "#FFD6D6", "#FFD9D9", "#FFDBDB", "#FFDEDE",
            "#FFE0E0", "#FFE3E3", "#FFE6E6", "#FFE8E8", "#FFEBEB", "#FFEDED", "#FFF0F0", "#FFF2F2",
            "#FFF5F5", "#FFF7F7", "#FFFAFA", "#FFFCFC", "#FFFFFF"
        };

        private static readonly string[] DARKENS =
        {
            "#FF0000", "#FA0000", "#F50000", "#F00000", "#EB0000", "#E60000", "#E00000", "#DB0000",
            "#D60000", "#D10000", "#CC0000", "#C70000", "#C20000", "#BD0000", "#B80000", "#B20000",
            "#AD0000", "#A80000", "#A30000", "#9E0000", "#990000", "#940000", "#8F0000", "#8A0000",
            "#850000", "#800000", "#7A0000", "#750000", "#700000", "#6B0000", "#660000", "#610000",
            "#5C0000", "#570000", "#520000", "#4C0000", "#470000", "#420000", "#3D0000", "#380000",
            "#330000", "#2E0000", "#290000", "#240000", "#1F0000", "#1A0000", "#140000", "#0F0000",
            "#0A0000", "#050000", "#000000", "#000000", "#000000", "#000000", "#000000", "#000000",
            "#000000", "#000000", "#000000", "#000000", "#000000", "#000000", "#000000", "#000000",
            "#000000", "#000000", "#000000", "#000000", "#000000", "#000000", "#000000", "#000000",
            "#000000", "#000000", "#000000", "#000000", "#000000", "#000000", "#000000", "#000000",
            "#000000", "#000000", "#000000", "#000000", "#000000", "#000000", "#000000", "#000000",
            "#000000", "#000000", "#000000", "#000000", "#000000", "#000000", "#000000", "#000000",
        };

        private static readonly string[] TINTS =
        {
            "#FF0000", "#FF0303", "#FF0505", "#FF0808", "#FF0A0A", "#FF0D0D", "#FF0F0F", "#FF1212",
            "#FF1414", "#FF1717", "#FF1A1A", "#FF1C1C", "#FF1F1F", "#FF2121", "#FF2424", "#FF2626",
            "#FF2929", "#FF2B2B", "#FF2E2E", "#FF3030", "#FF3333", "#FF3636", "#FF3838", "#FF3B3B",
            "#FF3D3D", "#FF4040", "#FF4242", "#FF4545", "#FF4747", "#FF4A4A", "#FF4C4C", "#FF4F4F",
            "#FF5252", "#FF5454", "#FF5757", "#FF5959", "#FF5C5C", "#FF5E5E", "#FF6161", "#FF6363",
            "#FF6666", "#FF6969", "#FF6B6B", "#FF6E6E", "#FF7070", "#FF7373", "#FF7575", "#FF7878",
            "#FF7A7A", "#FF7D7D", "#FF8080", "#FF8282", "#FF8585", "#FF8787", "#FF8A8A", "#FF8C8C",
            "#FF8F8F", "#FF9191", "#FF9494", "#FF9696", "#FF9999", "#FF9C9C", "#FF9E9E", "#FFA1A1",
            "#FFA3A3", "#FFA6A6", "#FFA8A8", "#FFABAB", "#FFADAD", "#FFB0B0", "#FFB2B2", "#FFB5B5",
            "#FFB8B8", "#FFBABA", "#FFBDBD", "#FFBFBF", "#FFC2C2", "#FFC4C4", "#FFC7C7", "#FFC9C9",
            "#FFCCCC", "#FFCFCF", "#FFD1D1", "#FFD4D4", "#FFD6D6", "#FFD9D9", "#FFDBDB", "#FFDEDE",
            "#FFE0E0", "#FFE3E3", "#FFE6E6", "#FFE8E8", "#FFEBEB", "#FFEDED", "#FFF0F0", "#FFF2F2",
            "#FFF5F5", "#FFF7F7", "#FFFAFA", "#FFFCFC", "#FFFFFF"
        };

        private static readonly string[] SHADES =
        {
            "#FF0000", "#FC0000", "#FA0000", "#F70000", "#F50000", "#F20000", "#F00000", "#ED0000",
            "#EB0000", "#E80000", "#E60000", "#E30000", "#E00000", "#DE0000", "#DB0000", "#D90000",
            "#D60000", "#D40000", "#D10000", "#CF0000", "#CC0000", "#C90000", "#C70000", "#C40000",
            "#C20000", "#BF0000", "#BD0000", "#BA0000", "#B80000", "#B50000", "#B20000", "#B00000",
            "#AD0000", "#AB0000", "#A80000", "#A60000", "#A30000", "#A10000", "#9E0000", "#9C0000",
            "#990000", "#960000", "#940000", "#910000", "#8F0000", "#8C0000", "#8A0000", "#870000",
            "#850000", "#820000", "#800000", "#7D0000", "#7A0000", "#780000", "#750000", "#730000",
            "#700000", "#6E0000", "#6B0000", "#690000", "#660000", "#630000", "#610000", "#5E0000",
            "#5C0000", "#590000", "#570000", "#540000", "#520000", "#4F0000", "#4C0000", "#4A0000",
            "#470000", "#450000", "#420000", "#400000", "#3D0000", "#3B0000", "#380000", "#360000",
            "#330000", "#300000", "#2E0000", "#2B0000", "#290000", "#260000", "#240000", "#210000",
            "#1F0000", "#1C0000", "#1A0000", "#170000", "#140000", "#120000", "#0F0000", "#0D0000",
            "#0A0000", "#080000", "#050000", "#030000", "#000000"
        };

        #endregion


        [Test]
        public void ConstructByName()
        {
            Assert.AreEqual("red", new TinyColor("red").ToName()); // create by name and then internally convert to name again
            Assert.AreEqual("blue", new TinyColor("blue").ToName()); // create by name and then internally convert to name again
            Assert.AreEqual("green", new TinyColor("green").ToName()); // create by name and then internally convert to name again
            Assert.AreEqual("white", new TinyColor("qqqqqqq").ToName()); // create by name and then internally convert to name again
            Assert.AreEqual("white", new TinyColor("aaaaaaa").ToName()); // create by name and then internally convert to name again
            Assert.AreEqual("white", new TinyColor(string.Empty).ToName()); // create by name and then internally convert to name again
        }

        [Test]
        public void ShouldClone()
        {
            // Instantiate the initial color
            TinyColor color1 = new TinyColor("red");

            // Clone the color
            TinyColor color2 = new TinyColor("red").Clone() as TinyColor;
            Assert.IsNotNull(color2);

            // Set alpha on the cloned color
            color2.A = 0.5f;

            // Assert the string representation of the cloned color
            Assert.AreEqual("1 0 0 0.5", color2.ToRGBA().ToString());

            // Assert the string representation of the original color is unchanged
            Assert.AreEqual("red", color1.ToName());
        }


        [Test]
        public void FromRGB()
        {
            Assert.IsTrue(new TinyColor(new TinyColor.RGB(1, 1, 1)).ToHex8String() == "#FFFFFFFF");
            Assert.IsTrue(new TinyColor(new TinyColor.RGBA(1, 0, 0, 0.5f)).ToRGBA().ToString() == "1 0 0 0.5");
            Assert.IsTrue(new TinyColor(new TinyColor.RGBA(1, 0, 0, 1f)).ToRGB().ToString() == "1 0 0");
            Assert.IsTrue(new TinyColor(new TinyColor.RGBA(1, 0, 0, 10f)).ToRGB().ToString() == "1 0 0");
            Assert.IsTrue(new TinyColor(new TinyColor.RGBA(1, 0, 0, -10f)).ToRGB().ToString() == "1 0 0");
            Assert.IsTrue(new TinyColor(new TinyColor.RGB(0.1f, 0.1f, 0.1f)).ToHex8String() == "#1A1A1AFF");
            // 0.1 * 255 = 25.5f. If the number ends in .5 so it is halfway between two integers,
            // one of which is even and the other odd, the even number is returned ( Mathf.RoundToInt docs) 
            // 26 to hex 1A
            // note:
            // This type of rounding is often used to minimize the overall rounding error introduced by rounding multiple numbers.
            // It tends to spread the rounding error equally in both directions(up and down).
        }

        [Test]
        public void ShouldParseHex()
        {
            Assert.IsTrue(TinyColor.ParseFromHex("#000").ToHex6String() == "#000000");
            Assert.IsTrue(TinyColor.ParseFromHex("#0000").ToHex6String() == "#000000");
            Assert.IsTrue(TinyColor.ParseFromHex("#000").A == 1.0f);
            Assert.IsTrue(TinyColor.ParseFromHex("#0000").A == 0.0f);
        }

        [Test]
        public void ParseRGB()
        {
            Assert.IsTrue(TinyColor.ParseFromRGB("1 0 0").ToHex6String() == "#FF0000");
            Assert.IsTrue(new TinyColor(new TinyColor.RGB(1, 0, 0)).ToHex6String() == "#FF0000");
            Assert.IsTrue(new TinyColor(new TinyColor.RGBA256(255, 0, 0, 255)).ToHex6String() == "#FF0000");
            Assert.IsTrue(new TinyColor(new TinyColor.RGB256(200, 100, 0)).ToRGB256().ToString() == "200 100 0");
            Assert.IsTrue(new TinyColor(new TinyColor.RGBA256(200, 100, 0, 8)).ToRGBA256().ToString() == "200 100 0 8");
        }

        [Test]
        public void ShouldParseHSL()
        {
            // to hex
            Assert.IsTrue(new TinyColor(new TinyColor.HSL(251, 1.0f, 0.38f)).ToHex6String() == "#2400C2");

            // to rgb
            Assert.IsTrue(new TinyColor(new TinyColor.HSL(251, 1.0f, 0.38f)).ToRGB256().ToString() == "36 0 194");

            // to hsl
            Assert.IsTrue(new TinyColor(new TinyColor.HSL(251, 1.0f, 0.38f)).ToHSL().ToString() == "251 1 0.38");
            Assert.IsTrue(new TinyColor(new TinyColor.HSLA(251, 1.0f, 0.38f, 0.38f)).ToHSLA().ToString() ==
                          "251 1 0.38 0.38");

            // problematic hsl
            Assert.IsTrue(new TinyColor(new TinyColor.HSL(100, 0.2f, 0.1f)).ToHSL().ToString() == "100 0.2 0.1");
            Assert.IsTrue(new TinyColor(new TinyColor.HSLA(100, 0.2f, 0.1f, 0.38f)).ToHSLA().ToString() ==
                          "100 0.2 0.1 0.38");

            // wrap out of bounds hue
            Assert.IsTrue(new TinyColor(new TinyColor.HSL(-700, 0.2f, 0.1f)).ToHSL().ToString() == "20 0.2 0.1");
            Assert.IsTrue(new TinyColor(new TinyColor.HSL(-490, 1.0f, 0.5f)).ToHSL().ToString() == "230 1 0.5");
        }

        [Test]
        public void ShouldParseRGBString()
        {
            Assert.IsTrue(TinyColor.ParseFromRGB256("255 0 0").ToHex6String() == "#FF0000");
            Assert.IsTrue(TinyColor.ParseFromRGB256("255 0 0 128").ToHex8String() == "#FF000080");
            Assert.IsTrue(TinyColor.ParseFromRGB256("255 0 0 0").ToHex8String() == "#FF000000");
            Assert.IsTrue(TinyColor.ParseFromRGB256("255 0 0 255").ToHex8String() == "#FF0000FF");
            Assert.IsTrue(TinyColor.ParseFromRGB256("255 0 0 0").ToHex8String() == "#FF000000");
        }

        [Test]
        public void ShouldParseHSVString()
        {
            Assert.IsTrue(TinyColor.ParseFromHSV("251.1 0.887 .918").ToHSV().ToString() == "251.1 0.887 0.918");
            Assert.IsTrue(TinyColor.ParseFromHSV("251.1 0.887 0.918").ToHSV().ToString() == "251.1 0.887 0.918");
            Assert.IsTrue(
                TinyColor.ParseFromHSV("251.1 0.887 0.918 0.5").ToHSVA().ToString() == "251.1 0.887 0.918 0.5");
        }

        [Test]
        public void ShouldParseInvalidInput()
        {
            Assert.IsNull(TinyColor.ParseFromName("not a color"));
            Assert.IsNull(TinyColor.ParseFromHex("not a color"));
            Assert.IsNull(TinyColor.ParseFromRGB("not a color"));
            Assert.IsNull(TinyColor.ParseFromRGB256("not a color"));
            Assert.IsNull(TinyColor.ParseFromHSL("not a color"));
            Assert.IsNull(TinyColor.ParseFromHSV("not a color"));
        }

        [Test]
        public void ShouldParseNamedColor()
        {
            Assert.IsTrue(TinyColor.ParseFromName("aliceblue").ToHex6String() == "#F0F8FF");
            Assert.IsTrue(TinyColor.ParseFromName("antiquewhite").ToHex6String() == "#FAEBD7");
            Assert.IsTrue(TinyColor.ParseFromName("aqua").ToHex6String() == "#00FFFF");
            Assert.IsTrue(TinyColor.ParseFromName("aquamarine").ToHex6String() == "#7FFFD4");
            Assert.IsTrue(TinyColor.ParseFromName("azure").ToHex6String() == "#F0FFFF");
            Assert.IsTrue(TinyColor.ParseFromName("beige").ToHex6String() == "#F5F5DC");
            Assert.IsTrue(TinyColor.ParseFromName("bisque").ToHex6String() == "#FFE4C4");

            Assert.IsTrue(TinyColor.ParseFromHex("#F00").ToName() == "red");
            Assert.IsTrue(TinyColor.ParseFromHex("#FA0A0A").ToName() == null);
        }

        [Test]
        public void ShouldNormalizeInvalidAlpha()
        {
            Assert.IsTrue(new TinyColor(new TinyColor.RGBA(1, 0.078f, 0.039f, -1)).Normalize().ToRGB256().ToString() ==
                          "255 20 10"); // Negative value
            Assert.IsTrue(new TinyColor(new TinyColor.RGBA(1, 0.078f, 0.039f, -0)).Normalize().ToRGB256().ToString() ==
                          "255 20 10"); // Negative 0
            Assert.IsTrue(new TinyColor(new TinyColor.RGBA(1, 0.078f, 0.039f, 0)).Normalize().ToRGBA256().ToString() ==
                          "255 20 10 0");
            Assert.IsTrue(
                new TinyColor(new TinyColor.RGBA(1, 0.078f, 0.039f, 0.5f)).Normalize().ToRGBA256().ToString() ==
                "255 20 10 128");
            Assert.IsTrue(new TinyColor(new TinyColor.RGBA(1, 0.078f, 0.039f, 1)).Normalize().ToRGBA256().ToString() ==
                          "255 20 10 255");
            Assert.IsTrue(new TinyColor(new TinyColor.RGBA(1, 0.078f, 0.039f, 1)).Normalize().ToRGB256().ToString() ==
                          "255 20 10");
            Assert.IsTrue(new TinyColor(new TinyColor.RGBA(1, 0.078f, 0.039f, 1)).Normalize().ToRGB256().ToString() ==
                          "255 20 10");

            Assert.IsTrue(TinyColor.ParseFromHex("#FFF").ToRGB256().ToString() == "255 255 255");
            Assert.IsTrue(TinyColor.ParseFromRGB256("255 0 0 258").ToRGB256().ToString() ==
                          "255 0 0"); // Greater than 1 in string parsing
        }

        [Test]
        public void ShouldTranslateToStringWithAlphaSet()
        {
            //const redNamed = fromRatio({ r: 255, g: 0, b: 0, a: 0.6 }, { format: 'name' });
            var redNamed = new TinyColor(new TinyColor.RGBA(1f, 0f, 0f, 0.6f));
            var redHex = new TinyColor(new TinyColor.RGBA(1f, 0f, 0f, 0.4f));
            Assert.IsTrue(redNamed.ToRGBA().ToString() == "1 0 0 0.6");
            Assert.IsTrue(redHex.ToRGBA().ToString() == "1 0 0 0.4");
            Assert.IsTrue(redNamed.ToHex6String() == "#FF0000");
            Assert.IsTrue(redNamed.ToHex8String() == "#FF000099");
            Assert.IsNull(redNamed.ToName());
            var transparentNamed = new TinyColor(new TinyColor.RGBA(1, 0, 0, 0));
            Assert.IsTrue(transparentNamed.ToName() == "transparent");
        }

        [Test]
        public void ShouldGetAlpha()
        {
            var hexSetter = TinyColor.ParseFromRGB256("255 0 0 255");
            Assert.IsTrue(Mathf.Approximately(hexSetter.A, 1f));
        }

        [Test]
        public void ShouldSetAlpha()
        {
            var hexSetter = TinyColor.ParseFromRGB256("255 0 0 255");
            Assert.IsTrue(Mathf.Approximately(hexSetter.A, 1f));

            hexSetter.A = -1;
            hexSetter = hexSetter.Normalize();
            Assert.IsTrue(Mathf.Approximately(hexSetter.A, 0f));

            hexSetter.A = 2f;
            hexSetter = hexSetter.Normalize();
            Assert.IsTrue(Mathf.Approximately(hexSetter.A, 1f));
        }

        [Test]
        public void ShouldGetBrightness()
        {
            foreach (var kv in Color.Colors)
            {
                var brightness = kv.Value.GetBrightness();
                Assert.IsTrue(brightness <= 1f);
                Assert.IsTrue(brightness >= 0f);
            }

            Assert.IsTrue(TinyColor.ParseFromHex("#000").GetBrightness() == 0f);
            Assert.IsTrue(TinyColor.ParseFromHex("#FFF").GetBrightness() == 1f);
        }

        [Test]
        public void ShouldGetLuminance()
        {
            Assert.IsTrue(TinyColor.ParseFromHex("#000").GetLuminance() == 0f);
            Assert.IsTrue(TinyColor.ParseFromHex("#FFF").GetLuminance() == 1f);
        }

        [Test]
        public void IsDark()
        {
            Assert.IsTrue(TinyColor.ParseFromHex("#000").IsDark());
            Assert.IsTrue(TinyColor.ParseFromHex("#111").IsDark());
            Assert.IsTrue(TinyColor.ParseFromHex("#222").IsDark());
            Assert.IsTrue(TinyColor.ParseFromHex("#333").IsDark());
            Assert.IsTrue(TinyColor.ParseFromHex("#444").IsDark());
            Assert.IsTrue(TinyColor.ParseFromHex("#555").IsDark());
            Assert.IsTrue(TinyColor.ParseFromHex("#666").IsDark());
            Assert.IsTrue(TinyColor.ParseFromHex("#777").IsDark());
            Assert.IsFalse(TinyColor.ParseFromHex("#888").IsDark());
            Assert.IsFalse(TinyColor.ParseFromHex("#999").IsDark());
            Assert.IsFalse(TinyColor.ParseFromHex("#AAA").IsDark());
            Assert.IsFalse(TinyColor.ParseFromHex("#BBB").IsDark());
            Assert.IsFalse(TinyColor.ParseFromHex("#CCC").IsDark());
            Assert.IsFalse(TinyColor.ParseFromHex("#DDD").IsDark());
            Assert.IsFalse(TinyColor.ParseFromHex("#EEE").IsDark());
            Assert.IsFalse(TinyColor.ParseFromHex("#FFF").IsDark());
        }

        [Test]
        public void IsLight()
        {
            Assert.IsFalse(TinyColor.ParseFromHex("#000").IsLight());
            Assert.IsFalse(TinyColor.ParseFromHex("#111").IsLight());
            Assert.IsFalse(TinyColor.ParseFromHex("#222").IsLight());
            Assert.IsFalse(TinyColor.ParseFromHex("#333").IsLight());
            Assert.IsFalse(TinyColor.ParseFromHex("#444").IsLight());
            Assert.IsFalse(TinyColor.ParseFromHex("#555").IsLight());
            Assert.IsFalse(TinyColor.ParseFromHex("#666").IsLight());
            Assert.IsFalse(TinyColor.ParseFromHex("#777").IsLight());
            Assert.IsTrue(TinyColor.ParseFromHex("#888").IsLight());
            Assert.IsTrue(TinyColor.ParseFromHex("#999").IsLight());
            Assert.IsTrue(TinyColor.ParseFromHex("#AAA").IsLight());
            Assert.IsTrue(TinyColor.ParseFromHex("#BBB").IsLight());
            Assert.IsTrue(TinyColor.ParseFromHex("#CCC").IsLight());
            Assert.IsTrue(TinyColor.ParseFromHex("#DDD").IsLight());
            Assert.IsTrue(TinyColor.ParseFromHex("#EEE").IsLight());
            Assert.IsTrue(TinyColor.ParseFromHex("#FFF").IsLight());
        }

        [Test]
        public void ColorEquality()
        {
            Assert.IsTrue(TinyColor.ParseFromHex("#FF0000").Equals(TinyColor.ParseFromHex("#Ff0000")));
            Assert.IsTrue(TinyColor.ParseFromHex("#FF0000").Equals(TinyColor.ParseFromRGB256("255 0 0")));
            Assert.IsTrue(TinyColor.ParseFromHex("#FF0000").Equals(TinyColor.ParseFromRGB("1 0 0")));
            Assert.IsFalse(TinyColor.ParseFromHex("#FF0000").Equals(TinyColor.ParseFromRGB256("255 0 0 1")));
            Assert.IsTrue(TinyColor.ParseFromHex("#FF000066").Equals(TinyColor.ParseFromRGB("1 0 0 .4")));
            Assert.IsTrue(TinyColor.ParseFromHex("#f009").Equals(TinyColor.ParseFromRGB("1 0 0 .6")));
            Assert.IsTrue(TinyColor.ParseFromHex("#336699CC").Equals(TinyColor.ParseFromHex("#369C")));
            Assert.IsTrue(TinyColor.ParseFromHex("#ffffff").Equals(TinyColor.ParseFromHex("#ffffff")));
            Assert.IsTrue(TinyColor.ParseFromHex("#f00").Equals(TinyColor.ParseFromHex("#ff0000")));
            Assert.IsTrue(TinyColor.ParseFromHex("#fff").Equals(TinyColor.ParseFromHex("#ffffff")));
            Assert.IsTrue(TinyColor.ParseFromHex("#00f").Equals(TinyColor.ParseFromHex("#0000ff")));
            Assert.IsTrue(TinyColor.ParseFromHex("#010101").Equals(TinyColor.ParseFromHex("#010101ff")));
            Assert.IsFalse(TinyColor.ParseFromHex("#ff0000").Equals(TinyColor.ParseFromHex("#00ff00")));
            Assert.IsTrue(TinyColor.ParseFromHex("#ff8000").Equals(TinyColor.ParseFromRGB("1 0.5 0")));
        }

        [Test]
        public void ColorIsReadable()
        {
            // "#ff0088", "#8822aa" (values used in old WCAG1 tests)
            Assert.IsTrue(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#000000"), TinyColor.ParseFromHex("#ffffff"), ReadabilityHelpers.WCAGLevel.AA, ReadabilityHelpers.WCAGSize.Small));
            Assert.IsFalse(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#ff0088"), TinyColor.ParseFromHex("#5c1a72")));
            Assert.IsFalse(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#ff0088"), TinyColor.ParseFromHex("#8822aa"), ReadabilityHelpers.WCAGLevel.AA, ReadabilityHelpers.WCAGSize.Small));
            Assert.IsFalse(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#ff0088"), TinyColor.ParseFromHex("#8822aa"), ReadabilityHelpers.WCAGLevel.AA, ReadabilityHelpers.WCAGSize.Large));
            Assert.IsFalse(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#ff0088"), TinyColor.ParseFromHex("#8822aa"), ReadabilityHelpers.WCAGLevel.AAA, ReadabilityHelpers.WCAGSize.Small));
            Assert.IsFalse(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#ff0088"), TinyColor.ParseFromHex("#8822aa"), ReadabilityHelpers.WCAGLevel.AAA, ReadabilityHelpers.WCAGSize.Small));

            // values derived from and validated using the calculators at http://www.dasplankton.de/ContrastA/
            // and http://webaim.org/resources/contrastchecker/

            // "#ff0088", "#5c1a72": contrast ratio 3.04
            Assert.IsFalse(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#ff0088"), TinyColor.ParseFromHex("#5c1a72"), ReadabilityHelpers.WCAGLevel.AA, ReadabilityHelpers.WCAGSize.Small));
            Assert.IsTrue(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#ff0088"), TinyColor.ParseFromHex("#5c1a72"), ReadabilityHelpers.WCAGLevel.AA, ReadabilityHelpers.WCAGSize.Large));
            Assert.IsFalse(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#ff0088"), TinyColor.ParseFromHex("#5c1a72"), ReadabilityHelpers.WCAGLevel.AAA, ReadabilityHelpers.WCAGSize.Small));
            Assert.IsFalse(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#ff0088"), TinyColor.ParseFromHex("#5c1a72"), ReadabilityHelpers.WCAGLevel.AAA, ReadabilityHelpers.WCAGSize.Large));

            // "#ff0088", "#2e0c3a": contrast ratio 4.56
            Assert.IsTrue(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#ff0088"), TinyColor.ParseFromHex("#2e0c3a"), ReadabilityHelpers.WCAGLevel.AA, ReadabilityHelpers.WCAGSize.Small));
            Assert.IsTrue(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#ff0088"), TinyColor.ParseFromHex("#2e0c3a"), ReadabilityHelpers.WCAGLevel.AA, ReadabilityHelpers.WCAGSize.Large));
            Assert.IsFalse(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#ff0088"), TinyColor.ParseFromHex("#2e0c3a"), ReadabilityHelpers.WCAGLevel.AAA, ReadabilityHelpers.WCAGSize.Small));
            Assert.IsTrue(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#ff0088"), TinyColor.ParseFromHex("#2e0c3a"), ReadabilityHelpers.WCAGLevel.AAA, ReadabilityHelpers.WCAGSize.Large));

            // "#db91b8", "#2e0c3a":  contrast ratio 7.12
            Assert.IsTrue(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#db91b8"), TinyColor.ParseFromHex("#2e0c3a"), ReadabilityHelpers.WCAGLevel.AA, ReadabilityHelpers.WCAGSize.Small));
            Assert.IsTrue(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#db91b8"), TinyColor.ParseFromHex("#2e0c3a"), ReadabilityHelpers.WCAGLevel.AA, ReadabilityHelpers.WCAGSize.Large));
            Assert.IsTrue(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#db91b8"), TinyColor.ParseFromHex("#2e0c3a"), ReadabilityHelpers.WCAGLevel.AAA, ReadabilityHelpers.WCAGSize.Small));
            Assert.IsTrue(ReadabilityHelpers.IsReadable(TinyColor.ParseFromHex("#db91b8"), TinyColor.ParseFromHex("#2e0c3a"), ReadabilityHelpers.WCAGLevel.AAA, ReadabilityHelpers.WCAGSize.Large));
        }

        [Test]
        public void Readabilty()
        {
            // check return values from readability function. See isReadable above for standards tests.
            Assert.IsTrue(Mathf.Approximately(ReadabilityHelpers.Readability(TinyColor.ParseFromHex("#000"), TinyColor.ParseFromHex("#000")), 1f));
            Assert.IsTrue(Mathf.Approximately(ReadabilityHelpers.Readability(TinyColor.ParseFromHex("#000"), TinyColor.ParseFromHex("#111")), 1.1121078324840545f));
            Assert.IsTrue(Mathf.Approximately(ReadabilityHelpers.Readability(TinyColor.ParseFromHex("#000"), TinyColor.ParseFromHex("#fff")), 21f));
        }

        [Test]
        public void MostReadable() 
        {
            Assert.IsTrue(ReadabilityHelpers.MostReadable(TinyColor.ParseFromHex("#000"), 
                new List<TinyColor>{ TinyColor.ParseFromHex("#111"), TinyColor.ParseFromHex("#222")})
                .ToHex6String() == "#222222");
            Assert.IsTrue(ReadabilityHelpers.MostReadable(TinyColor.ParseFromHex("#f00"),
                new List<TinyColor> { TinyColor.ParseFromHex("#d00"), TinyColor.ParseFromHex("#0d0") })
                .ToHex6String() == "#00DD00");
            Assert.IsTrue(ReadabilityHelpers.MostReadable(TinyColor.ParseFromHex("#fff"),
                new List<TinyColor> { TinyColor.ParseFromHex("#fff"), TinyColor.ParseFromHex("#fff") })
                .ToHex6String() == "#FFFFFF");
            Assert.IsTrue(ReadabilityHelpers.MostReadable(TinyColor.ParseFromHex("#fff"),
                new List<TinyColor> { TinyColor.ParseFromHex("#fff"), TinyColor.ParseFromHex("#fff")}, true)
                .ToHex6String() == "#000000");
            Assert.IsTrue(ReadabilityHelpers.MostReadable(TinyColor.ParseFromHex("#123"),
                new List<TinyColor> { TinyColor.ParseFromHex("#124"), TinyColor.ParseFromHex("#125") }, false)
                .ToHex6String() == "#112255");
            Assert.IsTrue(ReadabilityHelpers.MostReadable(TinyColor.ParseFromHex("#123"),
                new List<TinyColor> { TinyColor.ParseFromHex("#000"), TinyColor.ParseFromHex("#fff") }, false)
                .ToHex6String() == "#FFFFFF");
            Assert.IsTrue(ReadabilityHelpers.MostReadable(TinyColor.ParseFromHex("#123"),
                new List<TinyColor> { TinyColor.ParseFromHex("#124"), TinyColor.ParseFromHex("#125") }, true)
                .ToHex6String() == "#FFFFFF");
            Assert.IsTrue(ReadabilityHelpers.MostReadable(TinyColor.ParseFromHex("#ff0088"),
                new List<TinyColor> { TinyColor.ParseFromHex("#000"), TinyColor.ParseFromHex("#fff") }, false)
                .ToHex6String() == "#000000");
            Assert.IsTrue(ReadabilityHelpers.MostReadable(TinyColor.ParseFromHex("#ff0088"),
                new List<TinyColor> { TinyColor.ParseFromHex("#2e0c3a") }, true, ReadabilityHelpers.WCAGLevel.AAA, ReadabilityHelpers.WCAGSize.Large)
                .ToHex6String() == "#2E0C3A");
            Assert.IsTrue(ReadabilityHelpers.MostReadable(TinyColor.ParseFromHex("#ff0088"),
                new List<TinyColor> { TinyColor.ParseFromHex("#2e0c3a") }, true, ReadabilityHelpers.WCAGLevel.AAA, ReadabilityHelpers.WCAGSize.Small)
                .ToHex6String() == "#000000");
            Assert.IsTrue(ReadabilityHelpers.MostReadable(TinyColor.ParseFromHex("#371b2c"),
                new List<TinyColor> { TinyColor.ParseFromHex("#000"), TinyColor.ParseFromHex("#fff") }, false)
                .ToHex6String() == "#FFFFFF");
            Assert.IsTrue(ReadabilityHelpers.MostReadable(TinyColor.ParseFromHex("#371b2c"),
                new List<TinyColor> { TinyColor.ParseFromHex("#a9acb6") }, true, ReadabilityHelpers.WCAGLevel.AAA, ReadabilityHelpers.WCAGSize.Large)
                .ToHex6String() == "#A9ACB6");
            Assert.IsTrue(ReadabilityHelpers.MostReadable(TinyColor.ParseFromHex("#371b2c"),
                new List<TinyColor> { TinyColor.ParseFromHex("#a9acb6") }, true, ReadabilityHelpers.WCAGLevel.AAA, ReadabilityHelpers.WCAGSize.Small)
                .ToHex6String() == "#FFFFFF");
        }


        [Test]
        public void Modification()
        {
            for (var i = 0; i <= 100; i++)
                Assert.IsTrue(TinyColor.ParseFromName("red").Desaturate(i / 100f).ToHex6String() == DESATURATIONS[i]);

            for (var i = 0; i <= 100; i++)
                Assert.IsTrue(TinyColor.ParseFromName("red").Saturate(i / 100f).ToHex6String() == SATURATIONS[i]);

            for (var i = 0; i <= 100; i++)
                Assert.IsTrue(TinyColor.ParseFromName("red").Lighten(i / 100f).ToHex6String() == LIGHTENS[i]);

            for (var i = 0; i <= 100; i++)
                Assert.IsTrue(TinyColor.ParseFromName("red").Brighten(i / 100f).ToHex6String() == BRIGHTENS[i]);

            for (var i = 0; i <= 95; i++)
                Assert.IsTrue(TinyColor.ParseFromName("red").Darken(i / 100f).ToHex6String() == DARKENS[i]);

            for (var i = 0; i <= 100; i++)
                Assert.IsTrue(TinyColor.ParseFromName("red").Tint(i / 100f).ToHex6String() == TINTS[i]);

            for (var i = 0; i <= 100; i++)
                Assert.IsTrue(TinyColor.ParseFromName("red").Shade(i / 100f).ToHex6String() == SHADES[i]);

            Assert.IsTrue(TinyColor.ParseFromName("red").Greyscale().ToHex6String() == "#808080");
        }

        [Test]
        public void Spin()
        {
            //*it('Spin', () =>
            //{
            //    expect(Math.round(new TinyColor('#f00').spin(-1234).toHsl().h)).toBe(206);
            //    expect(Math.round(new TinyColor('#f00').spin(-360).toHsl().h)).toBe(0);
            //    expect(Math.round(new TinyColor('#f00').spin(-120).toHsl().h)).toBe(240);
            //    expect(Math.round(new TinyColor('#f00').spin(0).toHsl().h)).toBe(0);
            //    expect(Math.round(new TinyColor('#f00').spin(10).toHsl().h)).toBe(10);
            //    expect(Math.round(new TinyColor('#f00').spin(360).toHsl().h)).toBe(0);
            //    expect(Math.round(new TinyColor('#f00').spin(2345).toHsl().h)).toBe(185);

            //    [-360, 0, 360].forEach(delta =>
            //    {
            //        Object.keys(names).forEach(name =>
            //        {
            //            expect(new TinyColor(name).toHex()).toBe(new TinyColor(name).spin(delta).toHex());
            //        });
            //    });
            //});
        }

        [Test]
        public void Mix()
        {
            //    it('Mix', () => {
            //        // amount 0 or none
            //        expect(new TinyColor('#000').mix('#fff').toHsl().l).toBe(0.5);
            //        expect(new TinyColor('#f00').mix('#000', 0).toHex()).toBe('ff0000');
            //        // This case checks the the problem with floating point numbers (eg 255/90)
            //        expect(new TinyColor('#fff').mix('#000', 90).toHex()).toBe('1a1a1a');

            //        // black and white
            //        for (let i = 0; i < 100; i++)
            //        {
            //            expect(Math.round(new TinyColor('#000').mix('#fff', i).toHsl().l * 100) / 100).toBe(i / 100);
            //        }

            //        // with colors
            //        for (let i = 0; i < 100; i++)
            //        {
            //            let newHex = Math.round((255 * (100 - i)) / 100).toString(16);

            //            if (newHex.length === 1)
            //            {
            //                newHex = '0' + newHex;
            //            }

            //            expect(new TinyColor('#f00').mix('#000', i).toHex()).toBe(newHex + '0000');
            //            expect(new TinyColor('#0f0').mix('#000', i).toHex()).toBe(`00${ newHex}
            //            00`);
            //        expect(new TinyColor('#00f').mix('#000', i).toHex()).toBe('0000' + newHex);
            //        expect(new TinyColor('transparent').mix('#000', i).toRgb().a).toBe(i / 100);
            //    }
            //});
        }

        [Test]
        public void OnBackground()
        {
            //it('onBackground', () => {
            //    expect(new TinyColor('#ffffff').onBackground('#000').toHex()).toBe('ffffff');
            //    expect(new TinyColor('#ffffff00').onBackground('#000').toHex()).toBe('000000');
            //    expect(new TinyColor('#ffffff77').onBackground('#000').toHex()).toBe('777777');
            //    expect(new TinyColor('#262a6d82').onBackground('#644242').toHex()).toBe('443658');
            //    expect(new TinyColor('rgba(255,0,0,0.5)').onBackground('rgba(0,255,0,0.5)').toRgbString()).toBe(
            //      'rgba(170, 85, 0, 0.75)',

            //    );
            //    expect(new TinyColor('rgba(255,0,0,0.5)').onBackground('rgba(0,0,255,1)').toRgbString()).toBe(
            //      'rgb(128, 0, 128)',

            //    );
            //    expect(new TinyColor('rgba(0,0,255,1)').onBackground('rgba(0,0,0,0.5)').toRgbString()).toBe(
            //      'rgb(0, 0, 255)',

            //    );
            //});
        }

        [Test]
        public void Compliment()
        {
            //it('complement', () => {
            //    const complementDoesntModifyInstance = new TinyColor('red');
            //    expect(complementDoesntModifyInstance.complement().toHex()).toBe('00ffff');
            //    expect(complementDoesntModifyInstance.toHex()).toBe('ff0000');
            //});
        }

        [Test]
        public void Analogous()
        {
            //it('analogous', () => {
            //    const combination = new TinyColor('red').analogous();
            //    expect(colorsToHexString(combination)).toBe('ff0000,ff0066,ff0033,ff0000,ff3300,ff6600');
            //});
        }

        [Test]
        public void Monochromatic()
        {
            //it('monochromatic', () => {
            //    const combination = new TinyColor('red').monochromatic();
            //    expect(colorsToHexString(combination)).toBe('ff0000,2a0000,550000,800000,aa0000,d40000');
            //});
        }

        [Test]
        public void SplitComplement()
        {
            //it('splitcomplement', () => {
            //    const combination = new TinyColor('red').splitcomplement();
            //    expect(colorsToHexString(combination)).toBe('ff0000,ccff00,0066ff');
            //});
        }

        [Test]
        public void Triad()
        {
            //it('triad', () => {
            //    const combination = new TinyColor('red').triad();
            //    expect(colorsToHexString(combination)).toBe('ff0000,00ff00,0000ff');
            //});
        }

        [Test]
        public void Tetrad()
        {
            //it('tetrad', () => {
            //    const combination = new TinyColor('red').tetrad();
            //    expect(colorsToHexString(combination)).toBe('ff0000,80ff00,00ffff,7f00ff');
            //});
        }
    }
}