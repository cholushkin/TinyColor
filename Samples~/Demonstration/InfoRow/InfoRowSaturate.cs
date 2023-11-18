using UnityEngine.Assertions;

public class InfoRowSaturate : InfoRowBase
{
    public override void MakeLayout()
    {
        SetCaptionText("Saturate:");

        var clr = Demonstration.Instance.Selection;
        Assert.IsNotNull(clr);
        
        Clear();

        SetCaptionColor(clr);
        AddColor(clr.Saturate(0.1f), clr.Saturate(0.1f).ToHex6String());
        AddColor(clr.Saturate(0.2f), clr.Saturate(0.2f).ToHex6String());
        AddColor(clr.Saturate(0.3f), clr.Saturate(0.3f).ToHex6String());
        AddColor(clr.Saturate(0.4f), clr.Saturate(0.4f).ToHex6String());
        AddColor(clr.Saturate(0.5f), clr.Saturate(0.5f).ToHex6String());
        AddColor(clr.Saturate(0.6f), clr.Saturate(0.6f).ToHex6String());
        AddColor(clr.Saturate(0.7f), clr.Saturate(0.7f).ToHex6String());
        AddColor(clr.Saturate(0.8f), clr.Saturate(0.8f).ToHex6String());
        AddColor(clr.Saturate(0.9f), clr.Saturate(0.9f).ToHex6String());
        AddColor(clr.Saturate(1.0f), clr.Saturate(1.0f).ToHex6String());
    }
}