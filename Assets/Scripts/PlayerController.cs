using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    private float moveSpeed = 5f;
    private bool isMoving = false;
    private Vector2 moveDirection = Vector2.right;
    private float movement;
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        // player is touching the screen
        if (Input.GetMouseButtonDown(0))
        {
            moveDirection *= -1;
            isMoving = true;
        }

        // player stopped touching screen : should stop horizontal movement
        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }

        if (transform.position.x > 5)
        {
            
        }
    }

    private void FixedUpdate() 
    {
        if (isMoving)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
