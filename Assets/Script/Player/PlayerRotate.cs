using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour    //rotazione del player in base alla direzione di movimento
{

    bool isLeft = false ;

    private void Update() 
    {
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            if(isLeft == false) 
            {
                rotateMove(-180);
                isLeft = true;
            }
        }
        else if ( Input.GetAxisRaw("Horizontal") > 0)
        {
            if(isLeft)
            {
                rotateMove(180);
                isLeft = false;
            }
        }    
    }

    private void rotateMove(int dir)
    {
        gameObject.transform.Rotate(0,dir,0);
    }
}
