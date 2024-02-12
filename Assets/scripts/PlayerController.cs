using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    public float movementSpeed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();
    }

    
    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + (movement * movementSpeed * Time.fixedDeltaTime));
    }
}
