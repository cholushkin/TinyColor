using System.Reflection;
using UnityEngine;

public class ExamplePrintAllColors : MonoBehaviour
{
    void Start()
    {
        PrintAllColors();
    }

    void PrintAllColors()
    {
        var colorProperties = typeof(TinyColor.Color).GetProperties(BindingFlags.Public | BindingFlags.Static);

        int counter = 0;

        foreach (var kv in TinyColor.Color.Colors)
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
