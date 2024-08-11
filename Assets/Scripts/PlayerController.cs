using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed;
    private bool moveLeftDirection = true;
    Rigidbody2D rb;
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        if (Input.GetMouseButton(0))
        {
            if (moveLeftDirection)
            {
                // player moves in left direction
                moveLeftDirection = false;
            }
            else
            {
                // player moves in the right direction
                moveLeftDirection = true;
            }
        }
        else
        {

        }
    }
}
