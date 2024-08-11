using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardPlatform : MonoBehaviour
{
    [SerializeField] private float jumpForce = 8f;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.relativeVelocity.y <= 0f) // the player is coming from above
        {
            Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Vector2 velocity = rb.velocity;
                // velocity.y = jumpForce;
                // rb.velocity = velocity;

                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

    }
}
