using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInstructionsScreen : MonoBehaviour
{
    [SerializeField] private GameObject playInstructionsPanel;
    [SerializeField] private GameObject oneTouchControlInfoPanel;
    [SerializeField] private GameObject twoTouchControlInfoPanel;

    public void Awake() 
    {
        if (GameManager.showInstructions)
        {
            playInstructionsPanel.gameObject.SetActive(true);
            if (SettingsScreen.DifficultySetToEasy)
            {
                twoTouchControlInfoPanel.SetActive(true);
            }
            else
            {
                oneTouchControlInfoPanel.SetActive(true);
            }
            GameManager.showInstructions = false;
        }
        else
        {
            playInstructionsPanel.gameObject.SetActive(false);
        }
    }

    
    private void Update() 
    {
        if (Input.GetMouseButtonUp(0))
        {
            playInstructionsPanel.gameObject.SetActive(false);
        }
    }
}
