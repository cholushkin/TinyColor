using UnityEngine;
using TMPro;
using TinyColorLib;

public class Demonstration : MonoBehaviour
{
    public TinyColor Selection
    {
        get { return _selection; }
        set { SetColor(value); }
    }

    public TMP_InputField InputField;
    public RowsController RowsController;
    public ColorRect ColorPreview;

    public static Demonstration Instance;
    private TinyColor _selection = new TinyColor(UnityEngine.Color.black);

    
    private void Awake()
    {
        Instance = this;
    }

    
    public void SetColor(TinyColor value)
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
