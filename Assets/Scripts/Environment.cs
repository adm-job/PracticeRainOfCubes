using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private GameObject Ground;    
    [SerializeField] private GameObject ObstacleBlue;    
    [SerializeField] private GameObject ObstacleRed;    

    private float xPositionAll = 50;
    private float yPositionGroiund = 0;
    private float zPositionGroiund = 50;
    private float yPositionObstacleBlue = 9;
    private float zPositionObstacleBlue = 21;
    private float xRotationObstacleBlue = 55;
    private float yPositionObstacleRed = 27;
    private float zPositionObstacleRed = 6;
    private float xRorationObstacleRed = 37;


    public void Create()
    {
        Instantiate(Ground, new Vector3(xPositionAll, yPositionGroiund, zPositionGroiund), Quaternion.Euler(0, 0, 0));
        Instantiate(ObstacleBlue, new Vector3(xPositionAll, yPositionObstacleBlue, zPositionObstacleBlue), Quaternion.Euler(xRotationObstacleBlue, 0, 0));
        Instantiate(ObstacleRed, new Vector3(xPositionAll, yPositionObstacleRed, zPositionObstacleRed), Quaternion.Euler(xRorationObstacleRed, 0, 0));
    }


}
