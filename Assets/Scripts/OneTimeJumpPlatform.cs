using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeJumpPlatform : BasePlatform
{
    protected override void Start()
    {
        base.Start();
        soundVolume = 1;
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.relativeVelocity.y <= 0f) // the player is coming from above
        {
            Destroy(gameObject);
        }
    }
}
