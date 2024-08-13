using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardPlatform : MonoBehaviour
{
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private Transform player;
    private Camera mainCamera;
    private float lowerBound;
    private float platformDestroyBuffer = 1f;

    // [SerializeField] private AudioSource jumpSound;

    private void Start() 
    {
        mainCamera = Camera.main;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.relativeVelocity.y <= 0f) // the player is coming from above
        {
            Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if (FindObjectOfType<AudioManager>())
                {
                    FindObjectOfType<AudioManager>().Play("Jump");
                }
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    private void Update() 
    {
        lowerBound = mainCamera.transform.position.y - mainCamera.orthographicSize - platformDestroyBuffer;    

        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
