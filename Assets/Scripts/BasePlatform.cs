using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlatform : MonoBehaviour
{
    [SerializeField] protected float jumpForce;
    [SerializeField] protected AudioClip jumpSound;
    protected float soundVolume = 0.6f;
    protected Camera mainCamera;
    protected float lowerBound;
    protected float platformDestroyBuffer = 1f;

    protected virtual void Start()
    {
        jumpForce = 12f;
        mainCamera = Camera.main;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f) // the player is coming from above
        {
            AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position, soundVolume);
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    protected void Update()
    {
        lowerBound = mainCamera.transform.position.y - mainCamera.orthographicSize - platformDestroyBuffer;
        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
