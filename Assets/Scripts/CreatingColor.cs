using UnityEngine;

public class CreatingColo
    \r : MonoBehaviour
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
