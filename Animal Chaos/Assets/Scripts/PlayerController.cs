using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("Player Properties")]
    [SerializeField] private float movementSpeed = 350.0f;
    [SerializeField] private GameObject foodPrefabs;
    [SerializeField] private AudioClip throwClip;


    private float movementDirection;
    private Rigidbody rb;
    public Animator anim;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
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
            if(GameManager.Instance.IsGameOver())
            {
                rb.velocity = Vector3.zero;
                PlayerAnimState("GameOver");
                return;
            }
            else
            {
                rb.velocity = Vector3.zero;
                PlayerAnimState("Idle");
                return;
            }
        }

        Vector3 force = Vector3.right * movementDirection * movementSpeed * Time.deltaTime;
        rb.AddForce(force);

        PlayerAnimState(movementDirection < 0 ? "Strafe Left" : "Strafe Right");
    }

    public void HandleThrow()
    {
        Vector3 spawnPosition = transform.position + transform.forward;
        Instantiate(foodPrefabs, spawnPosition, Quaternion.identity);

        PlayerAnimState("Throw");

        AudioSource.PlayClipAtPoint(throwClip, Vector3.zero);
    }

    public void PlayerAnimState(string name)
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName(name)) return;

        anim.Play(name);
    }
}
