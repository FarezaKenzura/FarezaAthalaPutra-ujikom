using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("Player Properties")]
    [SerializeField] private float movementSpeed = 350.0f;
    [SerializeField] private GameObject foodPrefabs;

    private float movementDirection;
    private Rigidbody rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    } 

    private void Update() 
    {
        movementDirection = Input.GetAxis("Horizontal");

        if(IsThrowFood())
        {
            HandleThrow();
        }   
    }

    private void FixedUpdate() 
    {
        HandleMovement();
    }

    private bool IsThrowFood()
    {
        return Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
    }

    private void HandleMovement()
    {
        if(movementDirection == 0)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        Vector3 force = Vector3.right * movementDirection * movementSpeed * Time.deltaTime;
        rb.AddForce(force);
    }

    public void HandleThrow()
    {
        Vector3 spawnPosition = transform.position + transform.forward;
        Instantiate(foodPrefabs, spawnPosition, Quaternion.identity);
    }
}
