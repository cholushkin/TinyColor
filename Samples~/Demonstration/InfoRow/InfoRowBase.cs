using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;


public class InfoRowBase : MonoBehaviour
{
    public TextMeshProUGUI CaptionText;
    public GameObject ColorRectPrefab;
    public RectTransform Container;
    public Image Background;

 
    public void Start()
    {
        MakeLayout();
    }

    
    public void SetCaptionText(string text)
    {
        CaptionText.text = text;
    }

    
    public void Clear()
    {
        SetCaptionColor(TinyColor.TinyColor.ParseFromName("black"));
        foreach (Transform t in Container.transform)
            Destroy(t.gameObject);
    }

    
    public void SetCaptionColor(TinyColor.TinyColor color)
    {
        if (Background != null)
            Background.color = color.ToColor();
    }

    
    public void AddColor(TinyColor.TinyColor color, string text)
    {
        var clrRect = Instantiate(ColorRectPrefab, Container);
        clrRect.GetComponent<ColorRect>().SetColor(color);
        clrRect.GetComponent<ColorRect>().SetText(text);
    }

    
    public virtual void MakeLayout()
    {
    }
}