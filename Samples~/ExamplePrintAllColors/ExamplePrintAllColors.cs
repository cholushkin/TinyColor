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
        foreach (var property in colorProperties)
        {
            if (property.PropertyType != typeof(UnityEngine.Color))
                continue;

            UnityEngine.Color color = (UnityEngine.Color)property.GetValue(null, null);
            Debug.Log($"{property.Name}");
            ++counter;
        }
        Debug.Log($"{counter} color names");
    }
}
