using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip pickup;
    [SerializeField] private GameManager gameManager;
    private Rigidbody2D rb;

    public enum State { Play, Pause, GameOver }
    public State state = State.Play;

    private float moveSpeed = 6f;
    private Vector2 moveDirection = Vector2.right;
    private float screenMidPosition;
    private float interactableArea;
    private bool isMoving = false;
    private bool EasyGameMode = SettingsScreen.DifficultySetToEasy;
    private float smoothTime = 0.07f;
    private Vector2 currentVelocity;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Start()
    {
        screenMidPosition = Screen.width / 2;
        interactableArea = Screen.height / 2;
    }

    private void Update()
    {
        if (state == State.Play)
        {
            HandleTouchInput();
            //HandleKeyboardInput();
        }
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = isMoving && state == State.Play
            ? new Vector2(moveDirection.x * moveSpeed, rb.velocity.y)
            : new Vector2(0, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref currentVelocity, smoothTime);
    }

    private void HandleTouchInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            bool isInInteractableArea = mousePosition.y < interactableArea;

            if (EasyGameMode)
            {
                bool isLeftSide = mousePosition.x < screenMidPosition;
                moveDirection = isLeftSide ? Vector2.left : Vector2.right;
                isMoving = isInInteractableArea;
            }
            else if (isInInteractableArea)
            {
                moveDirection *= -1;
                isMoving = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }
    }

    private void HandleKeyboardInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection = Vector2.left;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = Vector2.right;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    public void StopGame()
    {
        state = State.Pause;
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
    }

    public void ResumeGame()
    {
        state = State.Play;
        rb.gravityScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickup"))
        {
            AudioSource.PlayClipAtPoint(pickup, Camera.main.transform.position, 1);
            gameManager.AddGems();
            Destroy(other.gameObject);
        }
    }
}
