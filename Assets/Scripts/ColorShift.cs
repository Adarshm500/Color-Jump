using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShift : MonoBehaviour
{
    [SerializeField] private Color[] playerColors;
    private int currentColorIndex = 0;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        SpriteRenderer otherSpriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();

        if (otherSpriteRenderer != null)
        {
            otherSpriteRenderer.color = playerColors[currentColorIndex];
            currentColorIndex = (currentColorIndex + 1) % playerColors.Length;
        }
    }
}
