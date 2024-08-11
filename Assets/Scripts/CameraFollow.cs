using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothSpeed = 0.3f;

    // private void Update() 
    // {

    // }

    private void LateUpdate() 
    {
        if (player.position.y > transform.position.y)
        {
            // Vector3 newPos = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);


            // transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed);
        }
    }

}
