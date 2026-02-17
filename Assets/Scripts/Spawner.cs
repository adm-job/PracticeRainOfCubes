using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
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
        _pool = new ObjectPool<Cube>
            (
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (cube) => GetOnAction(cube),
            actionOnRelease: (cube) => cube.Deactivate(),
            actionOnDestroy: (cube) => Destroy(cube.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
            );
    }

    private void GetOnAction(Cube cube)
    {
        cube.transform.position = new Vector3(Random.Range(_minXZ, _maxXZ), _positionY, Random.Range(_minXZ, _maxXZ));
        cube.Activate();

        cube.Collising += ReleaseCube;
    }

    private void Start()
    {
        StartCoroutine(StartCreation());
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

    private IEnumerator StartCreation()
    {
        while (true)
        {
            GetObject();

            yield return new WaitForSeconds(_repeatRate);
        }
    }
}

