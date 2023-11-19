using UnityEngine;

public class ExamplePrintAllColors : MonoBehaviour
{
    void Start()
    {
        PrintAllColors();
    }

    void PrintAllColors()
    {
        int counter = 0;

        foreach (var kv in TinyColorLib.Color.Colors)
        {
            var name = kv.Key;
            var color = kv.Value;
            var hex = color.ToHex6String(true);
            Debug.Log($"{name}, hex = <color=#{hex}>#{hex} </color>");
            ++counter;
        }
        Debug.Log($"{counter} color names");
    }
}
