using System.Collections.Generic;
using TinyColor;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorRect : MonoBehaviour, IPointerClickHandler
{
    public Image Image;
    public TextMeshProUGUI Text;
    public TinyColor.TinyColor TColor;
    private static List<TinyColor.TinyColor> _textColors = new List<TinyColor.TinyColor> { TinyColor.TinyColor.ParseFromName("white"), TinyColor.TinyColor.ParseFromName("black") };


    public void OnPointerClick(PointerEventData eventData)
    {
        Demonstration.Instance.Selection = TColor;
    }


    public void SetColor(TinyColor.TinyColor tColor)
    {
        Image.color = tColor.ToColor();
        TColor = tColor;

        var textColor = ReadabilityHelpers.MostReadable(TColor, _textColors);
        SetTextColor(textColor.ToColor());
    }


    public void SetText(string text)
    {
        if (Text == null)
            return;
        Text.text = text;
    }


    public void SetTextColor(UnityEngine.Color textColor)
    {
        if (Text == null)
            return;
        Text.color = textColor;
    }
}
