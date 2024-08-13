using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameOverScreen gameOverScreen;
    private float lowerBound;
    private float playerDestroyBuffer;

    private void Start() 
    {
        playerDestroyBuffer = 10f;
    }

    private void Update() 
    {
        lowerBound = transform.position.y - Camera.main.orthographicSize - playerDestroyBuffer;

        if (playerController.transform.position.y < lowerBound)
        {
            // stop the player and trigger gameOver
            playerController.state = PlayerController.State.Dead;
            gameOverScreen.Setup();
        }
    }
}
