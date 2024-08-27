using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public float cameraSpeed;
    public float cameraSpeedInitial = 1.5f;

    [SerializeField] private float cameraFollowSpeed = 3.5f;
    [SerializeField] private float cameraOffsetY = 5f;
    [SerializeField] PlayerController playerController;

    private float targetYPosition;

    private void Awake()
    {
        instance = this;
        cameraSpeed = cameraSpeedInitial;
        targetYPosition = transform.position.y;
    }

    private void LateUpdate()
    {
        if (playerController.state == PlayerController.State.Pause)
        {
            return;
        }

        targetYPosition += cameraSpeed * Time.deltaTime;

        float newYPosition = Mathf.Lerp(transform.position.y, targetYPosition, cameraFollowSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

        if (playerController.transform.position.y > transform.position.y + cameraOffsetY)
        {
            targetYPosition = playerController.transform.position.y - cameraOffsetY;
        }
    }
}
