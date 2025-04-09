using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorChanger : MonoBehaviour
{
    public GameObject square;

    public ShowPath P;


    public void OnMouseDown()
    {
        int[] Path = P.Path;
        string s = square.name;
        int index = Int32.Parse(s);


        if(isInside(index, Path))
        {
            
            square.SetActive(true);
            P.activatedSquares.Add(square);
            P.countGood += 1;
            if(P.countGood == Path.Length)
                P.levelPass(true);
        }
        else
        {
            P.i = 0;
            P.levelPass(false);
        } 
    }

    bool isInside(int index, int[] Path)
    {

        if(Path[P.i] == index)
        {
            P.i += 1;
            return true;
        }
        return false;
    }
}

