using System;
using System.Collections;
using UnityEngine;
using UnityEngine.tvOS;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(ColorChanger))]
public class Cube : MonoBehaviour
{
    private bool isCollision = false;
    private float _sleepTime = 5f;
    private ColorChanger _color;

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
        _color = GetComponent<ColorChanger>();
        
        if (isCollision)
        {
            return;
        }

        if (collision.gameObject.GetComponent<Platform>() != true)
        {
            return;
        }

        isCollision = true;

        Renderer.material.color = _color.GenerateNewColor();

        Debug.Log("this");
        StartCoroutine(StartingTimer());
    }

    private IEnumerator StartingTimer()
    {
        yield return new WaitForSeconds(_sleepTime);

        Renderer.material.color = _color.ReturnStandardColor();

        isCollision = false;

        Collising?.Invoke(this);
    }
}

