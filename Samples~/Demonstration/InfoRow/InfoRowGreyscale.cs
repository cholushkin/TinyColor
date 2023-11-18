using UnityEngine.Assertions;

public class InfoRowGreyscale : InfoRowBase
{
    public override void MakeLayout()
    {
        SetCaptionText("Greyscale:");

        var clr = Demonstration.Instance.Selection;
        Assert.IsNotNull(clr);
        
        Clear();

        SetCaptionColor(clr);
        AddColor(clr.Greyscale(), clr.Greyscale().ToHex6String());
    }
}