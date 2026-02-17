using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    [SerializeField] private Spawner _spawnerPool;
    [SerializeField] private CreateEnvironment _environment;


    private void Awake()
    {
        _environment.Create();
    }
}
