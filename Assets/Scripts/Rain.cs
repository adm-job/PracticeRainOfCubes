using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    [SerializeField] private SpawnerPool _spawnerPool;
    [SerializeField] private CreateEnvironment _environment;


    private void Awake()
    {
        _environment.Create();
    }
}
