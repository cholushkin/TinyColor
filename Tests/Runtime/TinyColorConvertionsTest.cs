using NUnit.Framework;
using Color = TinyColor.Color;

public class TinyColorConvertionsTest
{
    [Test]
    void TestColornames()
    {
        var a = Color.AliceBlue;
        Assert.IsTrue(a.r == 232);

    }
}
