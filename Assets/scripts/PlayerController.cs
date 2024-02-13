using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private float movementSpeed;

    [SerializeField] private Animator animator;
    [SerializeField] private float runSpeed =7.5f;
    [SerializeField] private float walkSpeed = 5f;

    [SerializeField]  private bool running;
    [SerializeField] private bool idle;
    
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = walkSpeed;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }

    
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleAnimations()
    {
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
    }

    private void HandleMovement()
    {
        movement.Normalize();
        rb.MovePosition((Vector2)transform.position + (movement * movementSpeed * Time.fixedDeltaTime));
    }

    private void HandleInputs()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            running = true;
            movementSpeed = runSpeed;
        }
        else
        {
            running = false;
            movementSpeed = walkSpeed;
        }
    }
}
