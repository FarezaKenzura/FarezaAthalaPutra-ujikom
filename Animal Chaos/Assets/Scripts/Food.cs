using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [Header("Food Properties")]
    [SerializeField] private float speed = 300.0f;
    [SerializeField] private float lifeTime = 3f;
    [SerializeField] private int score = 1;

    private Rigidbody rb;

    private void Start() 
    {
        Destroy(gameObject, lifeTime);

        rb = GetComponent<Rigidbody>();   
    }

    private void FixedUpdate() 
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 movement = Vector3.forward * speed * 0.01f * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Animal"))
        {
            Animal animal = other.GetComponent<Animal>();
            GameManager.Instance.AddScore(score);
            animal.DestroyThis();
            Destroy(gameObject);
        }    
    }
}
