using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class hitEnemy : MonoBehaviour
{
 
    public ShowPath P;

    public void OnMouseDown()
    {
        P.levelPass(false);
    }

}

