

using NUnit.Framework;

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
    }
}