using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GemsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gemCountText;
    [SerializeField] GameManager gameManager;


    private void Update() 
    {
        string gemsCollected = gameManager.GetGemsCollected().ToString();
        gemCountText.text = "x" + gemsCollected; 
    }
}
