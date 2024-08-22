using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update() 
    {
        string score = GameManager.GetScore().ToString();
        scoreText.text = score + "m"; 
    }
}
