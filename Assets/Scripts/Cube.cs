using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(MeshRenderer), typeof(ColorChanger))]
public class Cube : MonoBehaviour
{
    public event Action<Cube> Collising;
    
    private bool isCollision = false;
    private float _sleepTime = 5f;
    private ColorChanger _color;

    public MeshRenderer Renderer { get; private set; }

    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        Rigidbody = GetComponent<Rigidbody>();
        _color = GetComponent<ColorChanger>();
    }

    public void Activation()
    {
        gameObject.SetActive(true);
    }

    public void Deactivation()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (isCollision)
        {
            return;
        }

        if (collision.collider.TryGetComponent<Platform>(out _) != true)
        {
            return;
        }

        isCollision = true;

        Renderer.material.color = _color.GenerateNewColor();

        StartCoroutine(DeceptionDelay());

    }

    private IEnumerator DeceptionDelay()
    {
        yield return new WaitForSeconds(_sleepTime);

        Renderer.material.color = _color.ReturnStandardColor();

        isCollision = false;

        Collising?.Invoke(this);
    }
}

