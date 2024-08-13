using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private void Start() 
    {

    }

    private void Update() 
    {
        string score = GameManager.GetScore().ToString();
        scoreText.text = score; 
    }
}
