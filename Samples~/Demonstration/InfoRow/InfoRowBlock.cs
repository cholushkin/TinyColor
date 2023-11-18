using TinyColor;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class InfoRowBlock : InfoRowBase
{
    public TextMeshProUGUI Text;


    public override void MakeLayout()
    {
        SetCaptionText("Info:");

        var clr = Demonstration.Instance.Selection;
        Assert.IsNotNull(clr);

        SetCaptionColor(clr);

        var jsonText = JsonUtility.ToJson(clr.GetColorInfo(), true);
        Text.text = jsonText;
    }
}
