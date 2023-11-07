using NUnit.Framework;
using UnityEngine;

namespace TinyColor
{
    public class TinyColorModificationsTest
    {
        #region Test data
        private static readonly string[] DESATURATIONS = {
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

        private static readonly string[] SATURATIONS = {
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

        private static readonly string[] LIGHTENS = {
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

        private static readonly string[] BRIGHTENS = {
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

        private static readonly string[] DARKENS = {
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

        private static readonly string[] TINTS = {
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

        private static readonly string[] SHADES = {
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
            Assert.IsTrue(new TinyColor(new TinyColor.HSLA(251, 1.0f, 0.38f, 0.38f)).ToHSLA().ToString() == "251 1 0.38 0.38");

            // problematic hsl
            Assert.IsTrue(new TinyColor(new TinyColor.HSL(100, 0.2f, 0.1f)).ToHSL().ToString() == "100 0.2 0.1");
            Assert.IsTrue(new TinyColor(new TinyColor.HSLA(100, 0.2f, 0.1f, 0.38f)).ToHSLA().ToString() == "100 0.2 0.1 0.38");

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
            Assert.IsTrue(TinyColor.ParseFromHSV("251.1 0.887 0.918 0.5").ToHSVA().ToString() == "251.1 0.887 0.918 0.5");
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
            Assert.IsTrue(TinyColor.ParseFromName("aliceblue").ToHex6String()== "#F0F8FF");
            Assert.IsTrue(TinyColor.ParseFromName("antiquewhite").ToHex6String() == "#FAEBD7");
            Assert.IsTrue(TinyColor.ParseFromName("aqua").ToHex6String() == "#00FFFF");
            Assert.IsTrue(TinyColor.ParseFromName("aquamarine").ToHex6String() == "#7FFFD4");
            Assert.IsTrue(TinyColor.ParseFromName("azure").ToHex6String() == "#F0FFFF");
            Assert.IsTrue(TinyColor.ParseFromName("beige").ToHex6String() == "#F5F5DC");
            Assert.IsTrue(TinyColor.ParseFromName("bisque").ToHex6String() == "#FFE4C4");


            Assert.IsTrue(TinyColor.ParseFromHex("#F00").ToName() == "red");
            Assert.IsTrue(TinyColor.ParseFromHex("#FA0A0A").ToName() == null);
        }
    }
}