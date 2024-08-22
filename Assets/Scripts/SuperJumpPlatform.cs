using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJumpPlatform : BasePlatform
{
    protected override void Start()
    {
        base.Start();
        jumpForce = 20f;
        soundVolume = 1;
    }
}
