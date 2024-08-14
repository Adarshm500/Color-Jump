using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour
{
    private void Update() 
    {
        if (Input.GetMouseButton(0))
        {
            FindObjectOfType<AudioManager>().Play("Click");
            SceneManager.LoadScene("PlayScene");
        }
    }
}
