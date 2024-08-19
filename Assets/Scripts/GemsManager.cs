using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemsManager : MonoBehaviour
{
    [SerializeField] private Text gemCountText;
    [SerializeField] GameManager gameManager;


    private void Update() 
    {
        string gemsCollected = gameManager.GetGemsCollected().ToString();
        gemCountText.text = "x" + gemsCollected; 
    }
}
