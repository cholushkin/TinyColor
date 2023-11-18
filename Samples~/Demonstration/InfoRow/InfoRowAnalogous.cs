using UnityEngine.Assertions;

public class InfoRowAnalogous : InfoRowBase
{
    public override void MakeLayout()
    {
        SetCaptionText("Analogous:");

        var clr = Demonstration.Instance.Selection;
        Assert.IsNotNull(clr);

        Clear();

        SetCaptionColor(clr);
        var analogous = clr.Analogous();
        foreach (var a in analogous)
        {
            AddColor(a, a.ToHex6String());
        }
    }
}
