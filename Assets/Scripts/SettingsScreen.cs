using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : MonoBehaviour
{
    public static SettingsScreen instance;
    [SerializeField] private AudioClip click;


    public static bool DifficultySetToEasy = true;
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void EasyButton()
    {
        PlayClickSound();
        DifficultySetToEasy = true;
        gameObject.SetActive(false);
        GameManager.showInstructions = true;
    }

    public void DifficultButton()
    {
        PlayClickSound();
        DifficultySetToEasy = false;
        gameObject.SetActive(false);
        GameManager.showInstructions = true;
    }

    public void CloseButton()
    {
        PlayClickSound();
        gameObject.SetActive(false);
    }

    private void PlayClickSound()
    {
        AudioSource.PlayClipAtPoint(click, Camera.main.transform.position, 1f);
    }
}
