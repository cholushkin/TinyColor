using UnityEngine.Assertions;

public class InfoRowDarken : InfoRowBase
{
    public override void MakeLayout()
    {
        SetCaptionText("Darken:");

        var clr = Demonstration.Instance.Selection;
        Assert.IsNotNull(clr);
        
        Clear();

        SetCaptionColor(clr);
        AddColor(clr.Darken(0.1f), clr.Darken(0.1f).ToHex6String());
        AddColor(clr.Darken(0.2f), clr.Darken(0.2f).ToHex6String());
        AddColor(clr.Darken(0.3f), clr.Darken(0.3f).ToHex6String());
        AddColor(clr.Darken(0.4f), clr.Darken(0.4f).ToHex6String());
        AddColor(clr.Darken(0.5f), clr.Darken(0.5f).ToHex6String());
        AddColor(clr.Darken(0.6f), clr.Darken(0.6f).ToHex6String());
        AddColor(clr.Darken(0.7f), clr.Darken(0.7f).ToHex6String());
        AddColor(clr.Darken(0.8f), clr.Darken(0.8f).ToHex6String());
        AddColor(clr.Darken(0.9f), clr.Darken(0.9f).ToHex6String());
        AddColor(clr.Darken(1.0f), clr.Darken(1.0f).ToHex6String());
    }
}