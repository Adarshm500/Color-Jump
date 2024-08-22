using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public float cameraSpeed;
    public float cameraSpeedInitial = 1.5f;

    [SerializeField] private float cameraFollowSpeed = 3.5f;
    [SerializeField] private float cameraOffsetY = 5f;
    [SerializeField] PlayerController playerController;
    private void Awake()
    {
        instance = this;
        cameraSpeed = cameraSpeedInitial;
    }

    private void LateUpdate()
    {
        if (playerController.state == PlayerController.State.Pause)
        {
            return;
        }

        transform.position += new Vector3(0, cameraSpeed * Time.deltaTime, 0);

        // Check if the player is above the top of the camera's view
        if (playerController.transform.position.y > transform.position.y + cameraOffsetY)
        {
            // Move the camera upwards to keep the player on screen
            float newYPosition = Mathf.Lerp(transform.position.y, playerController.transform.position.y - cameraOffsetY, cameraFollowSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
        }
    }
}
