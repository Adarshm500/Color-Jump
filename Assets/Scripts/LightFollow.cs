using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollor : MonoBehaviour
{
    private void Update() 
    {
        transform.position = Camera.main.transform.position + new Vector3(6f, 10f, 10f);
    }
}
