using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private SettingsScreen settingsScreen;
    [SerializeField] private AudioClip click;


    public void StartButton()
    {
        SceneManager.LoadScene("PlayScene");
    }


    public void SettingsButton()
    {
        AudioSource.PlayClipAtPoint(click, transform.position, 1);
        settingsScreen.Setup();
    } 
    public void ExitGameButton()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
