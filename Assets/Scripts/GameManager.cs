using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private static int score;
    private int startPostion;
    private void Awake() 
    {
        instance = this;
        startPostion = (int)transform.position.y;
    }

    private void Update() 
    {
        score = (int)transform.position.y - startPostion;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void AddScore()
    {
        score += 10;
    }
}
