using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube Cube;
    
    private float _rainHeight = 50f;

    private void Start()
    {
        CreateRain();
    }

    private void CreateRain()
    {
         Instantiate(Cube, new Vector3(0, _rainHeight, 0 ), Quaternion.Euler(0, 0, 0));
        
    }
}





