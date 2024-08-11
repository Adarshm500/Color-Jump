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
        Debug.Log("movement direction" + moveDirection);
        // player is touching the screen
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("pressing the screen");
            // if the player is already moving reverse the direction
            moveDirection *= -1;
            isMoving = true;
            // if (moveLeftDirection)
            // {
            //     // player moves in left direction
            //     movement = -7;
            //     moveLeftDirection = false;
            // }
            // else
            // {
            //     // player moves in the right direction
            //     movement = 0f;
            //     moveLeftDirection = true;
            // }
        }

        // player stopped touching screen : should stop horizontal movement
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("stopped pressing the screen");
            isMoving = false;
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
