using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private bool isCollision = false;
    public event Action<Cube> Collising;

    public MeshRenderer Renderer { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    public void Activation()
    {
        gameObject.SetActive(true);
    }
    public void Deactivation()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Cube>() || isCollision)
        {
            return;
        }

        isCollision = true;
        
        Renderer.material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        StartCoroutine(EverySecond());
    }

    private IEnumerator EverySecond()
    {
        yield return new WaitForSeconds(5f);
        
        Renderer.material.color = Color.white;

        isCollision = false;
        
        Collising?.Invoke(this);
    }

}

