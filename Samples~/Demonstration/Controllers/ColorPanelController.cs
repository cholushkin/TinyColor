using System.Collections.Generic;
using TinyColor;
using UnityEngine;

public class ColorPanelController : MonoBehaviour
{
    public GameObject PrefabColorRect;
    public RectTransform Content;
    
    
    void Start()
    {
        int index = 0;
        List<TinyColor.TinyColor> textColors = new List<TinyColor.TinyColor>{ TinyColor.TinyColor.ParseFromName("white"), TinyColor.TinyColor.ParseFromName("black") };

        foreach(var kv in TinyColor.Color.Colors)
        {
            var colorName = kv.Key;
            var color = kv.Value.ToColor();
            var clrRectObj = Instantiate(PrefabColorRect, Content);
            var clrRect = clrRectObj.GetComponent<ColorRect>();
            var textColor = ReadabilityHelpers.MostReadable(kv.Value, textColors);
            clrRect.SetColor(kv.Value);
            clrRect.SetTextColor(textColor.ToColor());
            clrRect.SetText($"{++index:0000}");
        }
    }
}