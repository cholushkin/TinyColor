using UnityEngine.Assertions;

public class InfoRowBrighten : InfoRowBase
{
    public override void MakeLayout()
    {
        SetCaptionText("Brighten:");

        var clr = Demonstration.Instance.Selection;
        Assert.IsNotNull(clr);
        
        Clear();

        SetCaptionColor(clr);
        AddColor(clr.Brighten(0.1f), clr.Brighten(0.1f).ToHex6String());
        AddColor(clr.Brighten(0.2f), clr.Brighten(0.2f).ToHex6String());
        AddColor(clr.Brighten(0.3f), clr.Brighten(0.3f).ToHex6String());
        AddColor(clr.Brighten(0.4f), clr.Brighten(0.4f).ToHex6String());
        AddColor(clr.Brighten(0.5f), clr.Brighten(0.5f).ToHex6String());
        AddColor(clr.Brighten(0.6f), clr.Brighten(0.6f).ToHex6String());
        AddColor(clr.Brighten(0.7f), clr.Brighten(0.7f).ToHex6String());
        AddColor(clr.Brighten(0.8f), clr.Brighten(0.8f).ToHex6String());
        AddColor(clr.Brighten(0.9f), clr.Brighten(0.9f).ToHex6String());
        AddColor(clr.Brighten(1.0f), clr.Brighten(1.0f).ToHex6String());
    }
}