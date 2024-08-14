using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScreen : MonoBehaviour
{
    // private void Update() 
    // {
        
    // }
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject buttonGameObject;

    public void Setup()
    {
        gameObject.SetActive(true);
    }
    public void ResumeButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        gameObject.SetActive(false);
        buttonGameObject.SetActive(true);
        playerController.ResumeGame();
    }

    public void MenuButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("MainMenuScene");
    }
}
