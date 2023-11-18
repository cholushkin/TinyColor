using TinyColorLib;
using TMPro;
using UnityEngine;

public class ColorUserInputProcessor : MonoBehaviour
{
    public TMP_InputField InputField;


    public void OnValueEnter()
    {
        var clr = TinyColor.ParseFromHex("#"+InputField.text);
        if(clr != null )
        {
            Demonstration.Instance.SetColor(clr);
        }
    }
}
