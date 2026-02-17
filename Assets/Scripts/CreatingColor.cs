using UnityEngine;

public class CreatingColor : MonoBehaviour
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
