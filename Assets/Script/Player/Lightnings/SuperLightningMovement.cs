using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperLightningMovement : Lightning   //movimento del super fulmine
{
    [SerializeField]  float speed;
    private void Update()
    {
        Move(speed);
    }

    protected override void Move(float speed)
    {
        base.Move(speed);
    }
}
