using UnityEngine;
using TMPro;


public class Demonstration : MonoBehaviour
{
    public TinyColor.TinyColor Selection
    {
        get { return _selection; }
        set { SetColor(value); }
    }

    public TMP_InputField InputField;
    public RowsController RowsController;
    public ColorRect ColorPreview;

    public static Demonstration Instance;
    private TinyColor.TinyColor _selection = new TinyColor.TinyColor(Color.black);

    
    private void Awake()
    {
        Instance = this;
    }

    
    public void SetColor(TinyColor.TinyColor value)
    {
        InputField.text = value.ToHex6String(true);
        _selection = value;
        ColorPreview.SetColor(value);
        Refresh();
    }

    
    private void Refresh()
    {
        RowsController.Rebuild();
    }
}
