using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private int _poolCapacity = 100;
    [SerializeField] private int _poolMaxSize = 100;
    [SerializeField] private Environment _environment;

    private ObjectPool<GameObject> _pool;
    private Cube _cube;

    private void OnEnable()
    {
        _cube.Collising += ReleaseCube;
    }

    private void OnDisable()
    {
        _cube.Collising -= ReleaseCube;
    }

    private void Awake()
    {
        _environment.Create();

        _pool = new ObjectPool<GameObject>(
        createFunc: () => Instantiate(_prefab),
        actionOnGet: (obj) => ActionOnGet(obj),
        actionOnRelease: (obj) => obj.SetActive(false),
        actionOnDestroy: (obj) => Destroy(obj),
        collectionCheck: true,
        defaultCapacity: _poolCapacity,
        maxSize: _poolMaxSize);
    }

    private void ActionOnGet(GameObject obj)
    {
        obj.transform.position = _startPoint.transform.position;
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.SetActive(true);
    }

    private void Start()
    {
        InvokeRepeating(nameof(GetObject), 0.0f, _repeatRate);
    }

    private void GetObject()
    {
        _pool.Get();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Triger");
    //    Debug.Log(gameObject.activeInHierarchy);

    //    _pool.Release(gameObject);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Коллизия");
        _pool.Release(gameObject);

    }

    private void ReleaseCube(GameObject obj)
    {
        _pool.Release(obj);
    }
}

