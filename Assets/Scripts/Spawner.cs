using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Cube Cube;
    
    private float _rainHeight = 50f;

    private void Start()
    {
        CreatePoint();
    }

    private void CreatePoint()
    {
        GameObject point = new("PointRain");
        point.transform.position = new Vector3(0, _rainHeight, 0);
    }

}





