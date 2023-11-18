using UnityEngine.Assertions;

public class InfoRowTriad : InfoRowBase
{
    public override void MakeLayout()
    {
        SetCaptionText("Triad:");

        var clr = Demonstration.Instance.Selection;
        Assert.IsNotNull(clr);
        
        Clear();

        SetCaptionColor(clr);

        var triad = clr.Triad();
        foreach (var t in triad)
        {
            AddColor(t, t.ToHex6String());
        }
    }
}