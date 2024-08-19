using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject buttonGameObject;
    [SerializeField] private PauseMenuScreen pauseMenuScreen;
    public static GameManager instance;
    private static int score;
    private int gemsCollected;
    public static bool showInstructions = true;
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

    public int GetGemsCollected()
    {
        return gemsCollected;
    }

    public void AddGems()
    {
        FindObjectOfType<AudioManager>().Play("Pickup");
        gemsCollected++;
    }

    public void PauseButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        playerController.StopGame();
        buttonGameObject.SetActive(false);
        pauseMenuScreen.Setup();
    }
}
