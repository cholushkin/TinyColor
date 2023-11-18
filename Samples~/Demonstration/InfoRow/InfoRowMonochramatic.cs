using UnityEngine.Assertions;

public class InfoMonochromatic : InfoRowBase
{
    public override void MakeLayout()
    {
        SetCaptionText("Monochromatic:");

        var clr = Demonstration.Instance.Selection;
        Assert.IsNotNull(clr);
        
        Clear();

        SetCaptionColor(clr);

        var monochromatic = clr.Monochromatic();
        foreach (var t in monochromatic)
        {
            AddColor(t, t.ToHex6String());
        }
    }
}