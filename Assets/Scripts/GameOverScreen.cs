using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Text finalScoreText;
    [SerializeField] private Text finalGemCount;
    [SerializeField] GameManager gameManager;


    public void Setup()
    {
        gameObject.SetActive(true);
        finalScoreText.text = GameManager.GetScore().ToString() + "m";
        finalGemCount.text = "x" + gameManager.GetGemsCollected().ToString();
    }

    public void RestartButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("PlayScene");
    }

    public void ExitButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("MainMenuScene");
    }
}
