using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    private static GameOverScreen instance;
    [SerializeField] private Text finalScoreText;

    private void Awake() 
    {
        instance = this;
    }
    public void Setup()
    {
        gameObject.SetActive(true);
        finalScoreText.text = GameManager.GetScore().ToString() + "m";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
