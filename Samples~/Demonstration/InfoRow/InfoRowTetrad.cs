using UnityEngine.Assertions;

public class InfoRowTetrad : InfoRowBase
{
    public override void MakeLayout()
    {
        SetCaptionText("Tetrad:");

        var clr = Demonstration.Instance.Selection;
        Assert.IsNotNull(clr);
        
        Clear();

        SetCaptionColor(clr);

        var tetrad = clr.Tetrad();
        foreach (var t in tetrad)
        {
            AddColor(t, t.ToHex6String());
        }
    }
}