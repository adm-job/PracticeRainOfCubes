using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube Cube;
    [SerializeField] private Environment Environment;

    private float minValue = 0;
    private float maxValue = 100;

    private float _rainHeight = 50f;

    private void Awake()
    {
        Environment.Create();
    }

    public void PlayRain()
    {
        StartCoroutine(EverySecond());
    }

    private IEnumerator EverySecond()
    {
        while (true)
        {
            CreateRain();

            yield return new WaitForSeconds(0.01f);
        }
    }

    private void CreateRain()
    {
        float x = NewRandom();
        float z = NewRandom();

        Instantiate(Cube, new Vector3(x, _rainHeight, z), Quaternion.Euler(0, 0, 0));

    }

    private float NewRandom()
    {
        return Random.Range(minValue, maxValue);
    }
}





