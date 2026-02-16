using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
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
        Collising?.Invoke(this);
        Debug.Log("Коллизия");
    }
}

