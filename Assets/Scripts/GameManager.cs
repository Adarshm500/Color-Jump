using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject buttonGameObject;
    [SerializeField] private PauseMenuScreen pauseMenuScreen;
    [SerializeField] private AudioClip click;


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
        if (playerController.state == PlayerController.State.Play)
        {
            score = (int)transform.position.y - startPostion;
        }
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
        gemsCollected++;
    }

    public void PauseButton()
    {
        AudioSource.PlayClipAtPoint(click, Camera.main.transform.position, 1);
        playerController.StopGame();
        buttonGameObject.SetActive(false);
        pauseMenuScreen.Setup();
    }
}
