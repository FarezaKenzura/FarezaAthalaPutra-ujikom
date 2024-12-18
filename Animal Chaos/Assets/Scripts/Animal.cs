using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [Header("Animal Properties")]
    [SerializeField] private float speed;
    [SerializeField] private int score = 1;
    [SerializeField] private float lifeTime = 10.0f;

    private Rigidbody rb;
    private float lifeTimer;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        lifeTimer += Time.deltaTime;
        if(lifeTimer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() 
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 movement = transform.forward * speed * 0.01f * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
