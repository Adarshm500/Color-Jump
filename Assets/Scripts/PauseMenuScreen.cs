using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScreen : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject buttonGameObject;
    [SerializeField] private AudioClip click;


    public void Setup()
    {
        gameObject.SetActive(true);
    }
    public void ResumeButton()
    {
        AudioSource.PlayClipAtPoint(click, Camera.main.transform.position, 1);
        gameObject.SetActive(false);
        buttonGameObject.SetActive(true);
        playerController.ResumeGame();
    }

    public void MenuButton()
    {
        AudioSource.PlayClipAtPoint(click, Camera.main.transform.position, 1);
        SceneManager.LoadScene("MainMenuScene");
    }
}
