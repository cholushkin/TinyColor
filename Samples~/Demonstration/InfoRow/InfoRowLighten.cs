using UnityEngine.Assertions;

public class InfoRowLighten : InfoRowBase
{
    public override void MakeLayout()
    {
        SetCaptionText("Lighten:");

        var clr = Demonstration.Instance.Selection;
        Assert.IsNotNull(clr);
        
        Clear();

        SetCaptionColor(clr);
        AddColor(clr.Lighten(0.1f), clr.Lighten(0.1f).ToHex6String());
        AddColor(clr.Lighten(0.2f), clr.Lighten(0.2f).ToHex6String());
        AddColor(clr.Lighten(0.3f), clr.Lighten(0.3f).ToHex6String());
        AddColor(clr.Lighten(0.4f), clr.Lighten(0.4f).ToHex6String());
        AddColor(clr.Lighten(0.5f), clr.Lighten(0.5f).ToHex6String());
        AddColor(clr.Lighten(0.6f), clr.Lighten(0.6f).ToHex6String());
        AddColor(clr.Lighten(0.7f), clr.Lighten(0.7f).ToHex6String());
        AddColor(clr.Lighten(0.8f), clr.Lighten(0.8f).ToHex6String());
        AddColor(clr.Lighten(0.9f), clr.Lighten(0.9f).ToHex6String());
        AddColor(clr.Lighten(1.0f), clr.Lighten(1.0f).ToHex6String());
    }
}