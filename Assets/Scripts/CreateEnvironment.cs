using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateEnvironment : MonoBehaviour
{
    [SerializeField] private GameObject Ground;    
    [SerializeField] private GameObject ObstacleBlue;    
    [SerializeField] private GameObject ObstacleRed;
    [SerializeField] private Camera _camera;

    private float xPositionAll = 50;
    private float yPositionGround = 0;
    private float zPositionGround = 50;
    private float yPositionObstacleBlue = 9;
    private float zPositionObstacleBlue = 21;
    private float xRotationObstacleBlue = 55;
    private float yPositionObstacleRed = 27;
    private float zPositionObstacleRed = 6;
    private float xRotationObstacleRed = 37;
    private Vector3 _cameraPosition = new Vector3(144, 60, 43);
    private Quaternion _cameraRotation = Quaternion.Euler(29, -90, 0);

    private void Awake()
    {
        _camera.transform.position = _cameraPosition;
        _camera.transform.rotation = _cameraRotation;
    }

    public void Create()
    {
        Instantiate(Ground, new Vector3(xPositionAll, yPositionGround, zPositionGround), Quaternion.Euler(0, 0, 0));
        Instantiate(ObstacleBlue, new Vector3(xPositionAll, yPositionObstacleBlue, zPositionObstacleBlue), Quaternion.Euler(xRotationObstacleBlue, 0, 0));
        Instantiate(ObstacleRed, new Vector3(xPositionAll, yPositionObstacleRed, zPositionObstacleRed), Quaternion.Euler(xRotationObstacleRed, 0, 0));
    }


}
