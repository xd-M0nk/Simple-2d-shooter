using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private float moveInput;

    private Rigidbody2D rb;

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        
        moveInput = Input.GetAxisRaw("Horizontal");  

        
        MovePlayer();

        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))  
        {
            Jump();
        }
    }

    private void MovePlayer()
    {
        
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}