using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.tvOS;

public class SpawnerPool : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private int _poolCapacity = 100;
    [SerializeField] private int _poolMaxSize = 100;

    private float _minXZ = 1f;
    private float _maxXZ = 99f;
    private float _positionY = 50f;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool< Cube>(
        createFunc: () => Instantiate(_prefab),
        actionOnGet: (cube) => ActionOnGet(cube),
        actionOnRelease: (cube) => cube.Deactivation(),
        actionOnDestroy: (cube) => Destroy(cube),
        collectionCheck: true,
        defaultCapacity: _poolCapacity,
        maxSize: _poolMaxSize);
    }

    private void ActionOnGet(Cube cube)
    {
        cube.transform.position = new Vector3(Random.Range(_minXZ, _maxXZ), _positionY, Random.Range(_minXZ, _maxXZ));
        cube.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cube.Activation();
        
        cube.Collising += ReleaseCube;
    }

    private void Start()
    {
        InvokeRepeating(nameof(GetObject), 0.0f, _repeatRate);
    }

    private void GetObject()
    {
        _pool.Get();
    }

    private void ReleaseCube(Cube cube)
    {
        cube.Collising -= ReleaseCube;
        _pool.Release(cube);
    }
}

