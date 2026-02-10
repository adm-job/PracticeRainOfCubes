using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube Cube;
    [SerializeField] private Environment Environment;

    private float _rainHeight = 50f;

    private void Start()
    {
        Environment.Create();
        StartCoroutine(EverySecond());
    }

    IEnumerator EverySecond()
    {
        while (true)
        {
            Debug.Log("Прошло 1 секунда");
            CreateRain();
            
            yield return new WaitForSeconds(1f);
        }
    }

    private void CreateRain()
    {
        Instantiate(Cube, new Vector3(25, _rainHeight, 25), Quaternion.Euler(0, 0, 0));

    }
}





