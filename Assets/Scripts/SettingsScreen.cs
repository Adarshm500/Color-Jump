using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : MonoBehaviour
{
    public static SettingsScreen instance;

    public static bool DifficultySetToEasy = true;
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void EasyButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        DifficultySetToEasy = true;
        gameObject.SetActive(false);
        GameManager.showInstructions = true;
    }

    public void DifficultButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        DifficultySetToEasy = false;
        gameObject.SetActive(false);
        GameManager.showInstructions = true;
    }

    public void CloseButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        gameObject.SetActive(false);
    }
}
