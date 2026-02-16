using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color GenerateNewColor()
    {
        return Random.ColorHSV();
    }

    public Color ReturnStandartColor()
    {
        return Color.white;
    }
}
