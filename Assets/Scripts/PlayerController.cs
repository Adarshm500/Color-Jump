using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip pickup;
    public enum State
    {
        Play,
        Pause,
        GameOver,
    }

    public State state;

    Rigidbody2D rb;
    private float moveSpeed = 5f;
    private bool isMoving = false;
    private Vector2 moveDirection = Vector2.right;

    private float screenMidPosition = Screen.width / 2;
    private float interactableArea = Screen.height / 2;

    private bool EasyGameMode = SettingsScreen.DifficultySetToEasy;
    [SerializeField] GameManager gameManager;

    private void Awake() 
    {
        state = State.Play;
    }
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        if (state == State.Play)
        {
            if (EasyGameMode)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector2 mouseScreenPosition = Input.mousePosition;

                    if ((mouseScreenPosition.x < screenMidPosition) && (mouseScreenPosition.y < interactableArea))
                    {
                        moveDirection = Vector2.left;
                        isMoving = true;
                    }
                    else if ((mouseScreenPosition.x >= screenMidPosition) && (mouseScreenPosition.y < interactableArea))
                    {
                        moveDirection = Vector2.right;
                        isMoving = true;
                    }
                }
            }
            else
            {
                 // player is touching the screen
                if (Input.GetMouseButtonDown(0))
                {
                    Vector2 mouseScreenPosition = Input.mousePosition;

                    if (mouseScreenPosition.y < interactableArea)
                    {
                        moveDirection *= -1;
                        isMoving = true;
                    }
                }

                // player stopped touching screen : should stop horizontal movement
                else if (Input.GetMouseButtonUp(0))
                {
                    isMoving = false;
                }
            }
            // player is touching the screen

            // player stopped touching screen : should stop horizontal movement
            if (Input.GetMouseButtonUp(0))
            {
                isMoving = false;
            }
        }
    }

    private void FixedUpdate() 
    {
        if (isMoving && (state == State.Play))
        {
            if (EasyGameMode)
            {
                Vector2 mouseScreenPosition = Input.mousePosition;
                if (mouseScreenPosition.x < screenMidPosition)
                {
                    moveDirection = Vector2.left;
                }
                else if (mouseScreenPosition.x >= screenMidPosition)
                {
                    moveDirection = Vector2.right;
                }
                rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    public void StopGame()
    {
        state = State.Pause;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(0, 0);
    }

    public void ResumeGame()
    {
        state = State.Play;
        rb.gravityScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Pickup")
        {
            AudioSource.PlayClipAtPoint(pickup, Camera.main.transform.position, 1);
            gameManager.AddGems();
            Destroy(other.gameObject);
        }
    }
}
