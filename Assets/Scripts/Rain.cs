using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    [SerializeField] SpawnerPool _spawnerPool;
    [SerializeField] private Environment _environment;


    private void Awake()
    {
        _environment.Create();
    }
}
