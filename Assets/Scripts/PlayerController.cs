using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;

    public enum State
    {
        Alive,
        Dead
    }

    public State state;

    Rigidbody2D rb;
    private float moveSpeed = 5f;
    private bool isMoving = false;
    private Vector2 moveDirection = Vector2.right;

    public bool spawnOnMovingRight = true;
    public bool spawnOnMovingLeft = true;

    private void Awake() 
    {
        instance = this;  
        state = State.Alive;
    }
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        if (state == State.Alive)
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
        }
    }

    private void FixedUpdate() 
    {
        if (state == State.Alive)
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
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }
}
