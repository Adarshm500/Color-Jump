using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private float lowerBound;
    private void Update()
    {
        lowerBound = Camera.main.transform.position.y - Camera.main.orthographicSize;
        if (transform.position.y < lowerBound)
        {
            Destroy(this.gameObject);
        }
    }
}
