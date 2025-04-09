using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;



public class ShowPath : MonoBehaviour
{
    
    public TMP_Text Text;
    public GameObject[] allSquares;
    public GameObject squaresActivate;
    public SpriteRenderer backgroundColor;
    public GameObject background;
    public randomMove move;
    public timer countdown;
    public int[] Path;
    public int countGood;
    public bool clicked = false;
    public int numberWins = 0;
    public int i = 0;
    public List<GameObject> activatedSquares = new List<GameObject>();




    public void OnMouseDown()
    {
        if(!clicked)
        {
            countGood = 0;
            Path = findPath();
            StartCoroutine(ActivateSquares(Path));
            clicked = true;
            countdown.start = true;
            move.StartCoroutine(move.Lag());   
        }

    }

    public int[] findPath()
    {
        int[][] pathArray = new int[5][];

        pathArray[0] = new int[] {5, 12, 11, 10, 9, 16, 23, 24, 31, 38, 45};
        pathArray[1] = new int[] {6, 13, 12, 11, 18, 25, 32, 39, 38, 37, 44};
        pathArray[2] = new int[] {0, 1, 2, 9, 10, 17, 24, 31, 38, 37, 36, 43};
        pathArray[3] = new int[] {6, 13, 12, 11, 10, 9, 16, 15, 14, 21, 28, 35, 42};
        pathArray[4] = new int[] {3, 10, 17, 18, 25, 32, 31, 30, 37, 44};

        System.Random rnd = new System.Random();
        int i  = rnd.Next(0, 5);

        return pathArray[i];
    }

    private IEnumerator ActivateSquares(int[] Path)
    {
        
        for(int i = 0; i < Path.Length; i++)
        {
            GameObject square = allSquares[Path[i]];
            square.SetActive(true);

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1f);

        for(int i = 0; i < Path.Length; i++)
        {

            GameObject square = allSquares[Path[i]];
            square.SetActive(false);

        }

        squaresActivate.SetActive(true); 
        
        
    }

    public void levelPass(bool passed)
    {
        
        countGood = 0;
        i = 0;
        if(passed)
        {
            backgroundColor.color = new Color(.678f, 1f, 0.721f, 1f);
            background.SetActive(true);
            numberWins += 1;
            Text.text = "Completed: " + numberWins.ToString();
            Path = findPath();
        }
        else
        {
            backgroundColor.color = new Color(1f, 0.678f, 0.678f, 1f);
            background.SetActive(true);
            
        }

        StartCoroutine(restart());
        
    }

    private IEnumerator restart()
    {
        while(activatedSquares.Count > 0)
        {
            GameObject square = activatedSquares[0];
            activatedSquares.RemoveAt(0);
            square.SetActive(false);
        
        }

        yield return new WaitForSeconds(3f);
        squaresActivate.SetActive(false);
        background.SetActive(false);
        yield return new WaitForSeconds(2f);
        StartCoroutine(ActivateSquares(Path));

    }

}

