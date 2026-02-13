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

    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
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
        InvokeRepeating(nameof(GetCube), 0.0f, _repeatRate);
    }

    private void GetCube()
    {
        _pool.Get();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triger");
        Debug.Log(gameObject.activeInHierarchy);

        _pool.Release(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        Debug.Log(gameObject.activeInHierarchy);

        _pool.Release(gameObject);
    }
}

