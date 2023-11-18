using UnityEngine.Assertions;

public class InfoSplitComplements : InfoRowBase
{
    public override void MakeLayout()
    {
        SetCaptionText("Split complements:");

        var clr = Demonstration.Instance.Selection;
        Assert.IsNotNull(clr);
        
        Clear();

        SetCaptionColor(clr);
        var complements = clr.SplitComplement();
        foreach (var c in complements)
        {
            AddColor(c, c.ToHex6String());
        }
    }
}