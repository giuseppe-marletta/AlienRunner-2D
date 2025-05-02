using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalLightningMovement : Lightning //movimento del fulmine normale
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
