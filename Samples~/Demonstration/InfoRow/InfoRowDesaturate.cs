using UnityEngine.Assertions;

public class InfoRowDesaturate : InfoRowBase
{
    public override void MakeLayout()
    {
        SetCaptionText("Desaturate:");

        var clr = Demonstration.Instance.Selection;
        Assert.IsNotNull(clr);
        
        Clear();

        SetCaptionColor(clr);
        AddColor(clr.Desaturate(0.1f), clr.Desaturate(0.1f).ToHex6String());
        AddColor(clr.Desaturate(0.2f), clr.Desaturate(0.2f).ToHex6String());
        AddColor(clr.Desaturate(0.3f), clr.Desaturate(0.3f).ToHex6String());
        AddColor(clr.Desaturate(0.4f), clr.Desaturate(0.4f).ToHex6String());
        AddColor(clr.Desaturate(0.5f), clr.Desaturate(0.5f).ToHex6String());
        AddColor(clr.Desaturate(0.6f), clr.Desaturate(0.6f).ToHex6String());
        AddColor(clr.Desaturate(0.7f), clr.Desaturate(0.7f).ToHex6String());
        AddColor(clr.Desaturate(0.8f), clr.Desaturate(0.8f).ToHex6String());
        AddColor(clr.Desaturate(0.9f), clr.Desaturate(0.9f).ToHex6String());
        AddColor(clr.Desaturate(1.0f), clr.Desaturate(1.0f).ToHex6String());
    }
}