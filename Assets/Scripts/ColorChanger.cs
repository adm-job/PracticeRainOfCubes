using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color GenerateNewColor()
    {
        return Random.ColorHSV();
    }

    public Color ReturnStandardColor()
    {
        return Color.white;
    }
}
