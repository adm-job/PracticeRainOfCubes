using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color GenerateNewColor()
    {
        Debug.Log("Новый цвет");
        return Random.ColorHSV();
    }

    public Color ReturnStandardColor()
    {
        Debug.Log("Стандартный цвет");
        return Color.white;
    }
}
