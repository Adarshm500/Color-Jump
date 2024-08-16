using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private SettingsScreen settingsScreen;

    public void StartButton()
    {
        SceneManager.LoadScene("PlayScene");
    }


    public void SettingsButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        settingsScreen.Setup();
    } 
    public void ExitGameButton()
    {
        // Check if the game is running in the Unity editor
        #if UNITY_EDITOR
        // If running in the editor, stop play mode
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // If running in a build, quit the application
        Application.Quit();
        #endif
    }
}
