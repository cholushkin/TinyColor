using System;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

namespace TinyColor
{
    public class TinyColorModificationsTest
    {
        #region Test data

        private static readonly string[] DESATURATIONS =
        {
            "ff0000", "fe0101", "fc0303", "fb0404", "fa0505", "f90606", "f70808", "f60909", "f50a0a", "f40b0b",
            "f20d0d", "f10e0e", "f00f0f", "ee1111", "ed1212", "ec1313", "eb1414", "e91616", "e81717", "e71818",
            "e61919", "e41b1b", "e31c1c", "e21d1d", "e01f1f", "df2020", "de2121", "dd2222", "db2424", "da2525",
            "d92626", "d72828", "d62929", "d52a2a", "d42b2b", "d22d2d", "d12e2e", "d02f2f", "cf3030", "cd3232",
            "cc3333", "cb3434", "c93636", "c83737", "c73838", "c63939", "c43b3b", "c33c3c", "c23d3d", "c13e3e",
            "bf4040", "be4141", "bd4242", "bb4444", "ba4545", "b94646", "b84747", "b64949", "b54a4a", "b44b4b",
            "b34d4d", "b14e4e", "b04f4f", "af5050", "ad5252", "ac5353", "ab5454", "aa5555", "a85757", "a75858",
            "a65959", "a45b5b", "a35c5c", "a25d5d", "a15e5e", "9f6060", "9e6161", "9d6262", "9c6363", "9a6565",
            "996666", "986767", "966969", "956a6a", "946b6b", "936c6c", "916e6e", "906f6f", "8f7070", "8e7171",
            "8c7373", "8b7474", "8a7575", "887777", "877878", "867979", "857a7a", "837c7c", "827d7d", "817e7e",
            "808080"
        };

        private static readonly string[] SATURATIONS =
        {
            "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000",
            "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000",
            "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000",
            "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000",
            "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000",
            "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000",
            "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000",
            "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000",
            "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000",
            "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000",
            "ff0000", "ff0000", "ff0000", "ff0000", "ff0000", "ff0000"
        };

        private static readonly string[] LIGHTENS =
        {
            "ff0000", "ff0505", "ff0a0a", "ff0f0f", "ff1414", "ff1a1a", "ff1f1f", "ff2424",
            "ff2929", "ff2e2e", "ff3333", "ff3838", "ff3d3d", "ff4242", "ff4747", "ff4d4d",
            "ff5252", "ff5757", "ff5c5c", "ff6161", "ff6666", "ff6b6b", "ff7070", "ff7575",
            "ff7a7a", "ff8080", "ff8585", "ff8a8a", "ff8f8f", "ff9494", "ff9999", "ff9e9e",
            "ffa3a3", "ffa8a8", "ffadad", "ffb3b3", "ffb8b8", "ffbdbd", "ffc2c2", "ffc7c7",
            "ffcccc", "ffd1d1", "ffd6d6", "ffdbdb", "ffe0e0", "ffe5e5", "ffebeb", "fff0f0",
            "fff5f5", "fffafa", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff",
            "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff",
            "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff",
            "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff",
            "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff",
            "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff"
        };

        private static readonly string[] BRIGHTENS =
        {
            "ff0000", "ff0303", "ff0505", "ff0808", "ff0a0a", "ff0d0d", "ff0f0f", "ff1212",
            "ff1414", "ff1717", "ff1919", "ff1c1c", "ff1f1f", "ff2121", "ff2424", "ff2626",
            "ff2929", "ff2b2b", "ff2e2e", "ff3030", "ff3333", "ff3636", "ff3838", "ff3b3b",
            "ff3d3d", "ff4040", "ff4242", "ff4545", "ff4747", "ff4a4a", "ff4c4c", "ff4f4f",
            "ff5252", "ff5454", "ff5757", "ff5959", "ff5c5c", "ff5e5e", "ff6161", "ff6363",
            "ff6666", "ff6969", "ff6b6b", "ff6e6e", "ff7070", "ff7373", "ff7575", "ff7878",
            "ff7a7a", "ff7d7d", "ff7f7f", "ff8282", "ff8585", "ff8787", "ff8a8a", "ff8c8c",
            "ff8f8f", "ff9191", "ff9494", "ff9696", "ff9999", "ff9c9c", "ff9e9e", "ffa1a1",
            "ffa3a3", "ffa6a6", "ffa8a8", "ffabab", "ffadad", "ffb0b0", "ffb2b2", "ffb5b5",
            "ffb8b8", "ffbaba", "ffbdbd", "ffbfbf", "ffc2c2", "ffc4c4", "ffc7c7", "ffc9c9",
            "ffcccc", "ffcfcf", "ffd1d1", "ffd4d4", "ffd6d6", "ffd9d9", "ffdbdb", "ffdede",
            "ffe0e0", "ffe3e3", "ffe5e5", "ffe8e8", "ffebeb", "ffeded", "fff0f0", "fff2f2",
            "fff5f5", "fff7f7", "fffafa", "fffcfc", "ffffff"
        };

        private static readonly string[] DARKENS =
        {
            "ff0000", "fa0000", "f50000", "f00000", "eb0000", "e60000", "e00000", "db0000",
            "d60000", "d10000", "cc0000", "c70000", "c20000", "bd0000", "b80000", "b30000",
            "ad0000", "a80000", "a30000", "9e0000", "990000", "940000", "8f0000", "8a0000",
            "850000", "800000", "7a0000", "750000", "700000", "6b0000", "660000", "610000",
            "5c0000", "570000", "520000", "4d0000", "470000", "420000", "3d0000", "380000",
            "330000", "2e0000", "290000", "240000", "1f0000", "190000", "140000", "0f0000",
            "0a0000", "050000", "000000", "000000", "000000", "000000", "000000", "000000",
            "000000", "000000", "000000", "000000", "000000", "000000", "000000", "000000",
            "000000", "000000", "000000", "000000", "000000", "000000", "000000", "000000",
            "000000", "000000", "000000", "000000", "000000", "000000", "000000", "000000",
            "000000", "000000", "000000", "000000", "000000", "000000", "000000", "000000",
            "000000", "000000", "000000", "000000", "000000", "000000", "000000", "000000",
        };

        private static readonly string[] TINTS =
        {
            "ff0000", "ff0303", "ff0505", "ff0808", "ff0a0a", "ff0d0d", "ff0f0f", "ff1212",
            "ff1414", "ff1717", "ff1a1a", "ff1c1c", "ff1f1f", "ff2121", "ff2424", "ff2626",
            "ff2929", "ff2b2b", "ff2e2e", "ff3030", "ff3333", "ff3636", "ff3838", "ff3b3b",
            "ff3d3d", "ff4040", "ff4242", "ff4545", "ff4747", "ff4a4a", "ff4d4d", "ff4f4f",
            "ff5252", "ff5454", "ff5757", "ff5959", "ff5c5c", "ff5e5e", "ff6161", "ff6363",
            "ff6666", "ff6969", "ff6b6b", "ff6e6e", "ff7070", "ff7373", "ff7575", "ff7878",
            "ff7a7a", "ff7d7d", "ff8080", "ff8282", "ff8585", "ff8787", "ff8a8a", "ff8c8c",
            "ff8f8f", "ff9191", "ff9494", "ff9696", "ff9999", "ff9c9c", "ff9e9e", "ffa1a1",
            "ffa3a3", "ffa6a6", "ffa8a8", "ffabab", "ffadad", "ffb0b0", "ffb3b3", "ffb5b5",
            "ffb8b8", "ffbabab", "ffbdbd", "ffbfbf", "ffc2c2", "ffc4c4", "ffc7c7", "ffc9c9",
            "ffcccc", "ffcfcf", "ffd1d1", "ffd4d4", "ffd6d6", "ffd9d9", "ffdbdb", "ffdede",
            "ffe0e0", "ffe3e3", "ffe6e6", "ffe8e8", "ffebeb", "ffeded", "fff0f0", "fff2f2",
            "fff5f5", "fff7f7", "fffafa", "fffcfc", "ffffff"
        };

        private static readonly string[] SHADES =
        {
            "ff0000", "fc0000", "fa0000", "f70000", "f50000", "f20000", "f00000", "ed0000",
            "eb0000", "e80000", "e60000", "e30000", "e00000", "de0000", "db0000", "d90000",
            "d60000", "d40000", "d10000", "cf0000", "cc0000", "c90000", "c70000", "c40000",
            "c20000", "bf0000", "bd0000", "ba0000", "b80000", "b50000", "b30000", "b00000",
            "ad0000", "ab0000", "a80000", "a60000", "a30000", "a10000", "9e0000", "9c0000",
            "990000", "960000", "940000", "910000", "8f0000", "8c0000", "8a0000", "870000",
            "850000", "820000", "800000", "7d0000", "7a0000", "780000", "750000", "730000",
            "700000", "6e0000", "6b0000", "690000", "660000", "630000", "610000", "5e0000",
            "5c0000", "590000", "570000", "540000", "520000", "4f0000", "4d0000", "4a0000",
            "470000", "450000", "420000", "400000", "3d0000", "3b0000", "380000", "360000",
            "330000", "300000", "2e0000", "2b0000", "290000", "260000", "240000", "210000",
            "1f0000", "1c0000", "1a0000", "170000", "140000", "120000", "0f0000", "0d0000",
            "0a0000", "080000", "050000", "030000", "000000"
        };

        #endregion


        [Test]
        public void ConstructByName()
        {
            Assert.AreEqual("red",
                new TinyColor("red").ToName()); // create by name and then internally convert to name again
            Assert.AreEqual("blue",
                new TinyColor("blue").ToName()); // create by name and then internally convert to name again
            Assert.AreEqual("green",
                new TinyColor("green").ToName()); // create by name and then internally convert to name again

            Assert.AreEqual("white",
                new TinyColor("qqqqqqq").ToName()); // create by name and then internally convert to name again
            Assert.AreEqual("white",
                new TinyColor("aaaaaaa").ToName()); // create by name and then internally convert to name again
            Assert.AreEqual("white",
                new TinyColor(string.Empty).ToName()); // create by name and then internally convert to name again
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
            //// check return values from readability function. See isReadable above for standards tests.
            //expect(readability('#000', '#000')).toBe(1);
            //expect(readability('#000', '#111')).toBe(1.1121078324840545);
            //expect(readability('#000', '#fff')).toBe(21);
        }

        [Test]
        public void MostReadable() 
        {

            //    *it('mostReadable', () =>
            //    {
            //    expect(mostReadable('#000', ['#111', '#222'])!.toHexString()).toBe('#222222');
            //    expect(mostReadable('#f00', ['#d00', '#0d0'])!.toHexString()).toBe('#00dd00');
            //    expect(
            //      mostReadable(new TinyColor('#f00'), [
            //        new TinyColor('#d00'),
            //        new TinyColor('#0d0'),
            //      ])!.toHexString(),

            //    ).toBe('#00dd00');
            //    expect(mostReadable('#fff', ['#fff', '#fff'])!.toHexString()).toBe('#ffffff');
            //    // includeFallbackColors
            //    expect(
            //      mostReadable('#fff', ['#fff', '#fff'], { includeFallbackColors: true })!.toHexString(),
            //            ).toBe('#000000');
            //    // no readable color in list
            //    expect(
            //      mostReadable('#123', ['#124', '#125'], { includeFallbackColors: false })!.toHexString(),
            //            ).toBe('#112255');
            //    expect(
            //      mostReadable('#123', ['#000', '#fff'], { includeFallbackColors: false })!.toHexString(),
            //            ).toBe('#ffffff');
            //    // no readable color in list
            //    expect(
            //      mostReadable('#123', ['#124', '#125'], { includeFallbackColors: true })!.toHexString(),
            //            ).toBe('#ffffff');

            //    expect(
            //      mostReadable('#ff0088', ['#000', '#fff'], { includeFallbackColors: false })!.toHexString(),
            //            ).toBe('#000000');
            //    expect(
            //      mostReadable('#ff0088', ['#2e0c3a'], {
            //    includeFallbackColors: true,
            //                level: 'AAA',
            //                size: 'large',
            //              })!.toHexString(),
            //            ).toBe('#2e0c3a');
            //    expect(
            //      mostReadable('#ff0088', ['#2e0c3a'], {
            //    includeFallbackColors: true,
            //                level: 'AAA',
            //                size: 'small',
            //              })!.toHexString(),
            //            ).toBe('#000000');

            //    expect(
            //      mostReadable('#371b2c', ['#000', '#fff'], { includeFallbackColors: false })!.toHexString(),
            //            ).toBe('#ffffff');
            //    expect(
            //      mostReadable('#371b2c', ['#a9acb6'], {
            //    includeFallbackColors: true,
            //                level: 'AAA',
            //                size: 'large',
            //              })!.toHexString(),
            //            ).toBe('#a9acb6');
            //    expect(
            //      mostReadable('#371b2c', ['#a9acb6'], {
            //    includeFallbackColors: true,
            //                level: 'AAA',
            //                size: 'small',
            //              })!.toHexString(),
            //            ).toBe('#ffffff');
            //});
             
        }

        [Test]
        public void ToMsFilter()
        {
            //*it('should create microsoft filter', () =>
            //{
            //    expect(toMsFilter('red')).toBe(
            //      'progid:DXImageTransform.Microsoft.gradient(startColorstr=#ffff0000,endColorstr=#ffff0000)',

            //    );
            //    expect(toMsFilter('red', 'blue')).toBe(
            //      'progid:DXImageTransform.Microsoft.gradient(startColorstr=#ffff0000,endColorstr=#ff0000ff)',

            //    );

            //    expect(toMsFilter('transparent')).toBe(
            //      'progid:DXImageTransform.Microsoft.gradient(startColorstr=#00000000,endColorstr=#00000000)',

            //    );
            //    expect(toMsFilter('transparent', 'red')).toBe(
            //      'progid:DXImageTransform.Microsoft.gradient(startColorstr=#00000000,endColorstr=#ffff0000)',

            //    );

            //    expect(toMsFilter('#f0f0f0dd')).toBe(
            //      'progid:DXImageTransform.Microsoft.gradient(startColorstr=#ddf0f0f0,endColorstr=#ddf0f0f0)',

            //    );
            //    expect(toMsFilter('rgba(0, 0, 255, .5')).toBe(
            //      'progid:DXImageTransform.Microsoft.gradient(startColorstr=#800000ff,endColorstr=#800000ff)',

            //    );
            //});
        }

        [Test]
        public void Modification()
        {

            //it('Modifications', () =>
            //{
            //    for (let i = 0; i <= 100; i++)
            //    {
            //        expect(new TinyColor('red').desaturate(i).toHex()).toBe(DESATURATIONS[i]);
            //    }

            //    for (let i = 0; i <= 100; i++)
            //    {
            //        expect(new TinyColor('red').saturate(i).toHex()).toBe(SATURATIONS[i]);
            //    }

            //    for (let i = 0; i <= 100; i++)
            //    {
            //        expect(new TinyColor('red').lighten(i).toHex()).toBe(LIGHTENS[i]);
            //    }

            //    for (let i = 0; i <= 100; i++)
            //    {
            //        expect(new TinyColor('red').brighten(i).toHex()).toBe(BRIGHTENS[i]);
            //    }

            //    for (let i = 0; i <= 100; i++)
            //    {
            //        expect(new TinyColor('red').darken(i).toHex()).toBe(DARKENS[i]);
            //    }

            //    for (let i = 0; i <= 100; i++)
            //    {
            //        expect(new TinyColor('red').tint(i).toHex()).toBe(TINTS[i]);
            //    }

            //    for (let i = 0; i <= 100; i++)
            //    {
            //        expect(new TinyColor('red').shade(i).toHex()).toBe(SHADES[i]);
            //    }

            //    expect(new TinyColor('red').greyscale().toHex()).toBe('808080');
            //});
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