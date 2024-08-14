using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject buttonGameObject;
    [SerializeField] private PauseMenuScreen pauseMenuScreen;
    private static GameManager instance;
    private static int score;
    private int startPostion;
    private void Awake() 
    {
        instance = this;
        startPostion = (int)transform.position.y;
    }

    private void Update() 
    {
        score = (int)transform.position.y - startPostion;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void AddScore()
    {
        score += 10;
    }

    public void PauseButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        playerController.StopGame();
        buttonGameObject.SetActive(false);
        pauseMenuScreen.Setup();
    }
}
