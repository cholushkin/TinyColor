using UnityEngine;

public class RowsController : MonoBehaviour
{
    public InfoRowBase[] Rows;

    
    public void Start()
    {
        Rebuild();
    }


    internal void Rebuild()
    {
        foreach (var row in Rows)
            row.MakeLayout();
    }
}
