using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMove : MonoBehaviour
{
    public List<GameObject> objects;
    public List<float> Path;
    public float wait;
    private int moveCounter = 0;
    

    /*void Start()
    {
        for(int i = 0; i < objects.Count; i++)
        {
            GameObject obj = objects[i];
            float currX = obj.transform.position.x;
            float currY = obj.transform.position.y;
            xList.Add(currX);
            yList.Add(currY);
        }
    }*/

    void Start()
    {
        StartCoroutine(Lag());
    }

    public IEnumerator Lag()    
    {
        yield return new WaitForSeconds(wait);
        Move();
        StartCoroutine(Lag());
    }


    void Move()
    {

        
        for(int i = 0; i < objects.Count; i++)
        {
            GameObject obj = objects[i];
            Vector3 startPosition = obj.transform.position;
            Vector3 newPosition = startPosition;
            int x, y;
            System.Random rnd = new System.Random();
            x  = rnd.Next(0, 10);
            y = rnd.Next(0, 10);

            if(x < 4)
            {
                if(newPosition.x + 1.32f > 2.1f)
                    newPosition.x -= 1.32f;
                else
                    newPosition.x += 1.32f;   
            }
            else if(x < 8)
            {
                if(newPosition.x - 1.32f < -4.1f)
                    newPosition.x += 1.32f;
                else
                    newPosition.x -= 1.32f;   
            }
            if(y < 4)
            {
                if(newPosition.y + 1.32f > 4.1f)
                    newPosition.y -= 1.32f;
                else
                    newPosition.y += 1.32f;
            }
            else if(y < 8)
            {
                if(newPosition.y - 1.32f < -4.1f)
                    newPosition.y += 1.32f;
                else
                    newPosition.y -= 1.32f;
            }

            obj.transform.position = newPosition;


        }


    }

    /*void Move()
    {
        moveCounter++;

        List<Vector2> occupiedPositions = new List<Vector2>();
        List<Vector2> clearPathPositions = new List<Vector2>();
        
        for(int i = 0; i < objects.Count; i++)
        {
            bool clear = true;  //when true clear path. clear every 2 beats.
            GameObject obj = objects[i];
            Vector3 startPosition = obj.transform.position;
            Vector3 newPosition = startPosition;
            int x, y;
            System.Random rnd = new System.Random();
            x  = rnd.Next(0, 10);
            y = rnd.Next(0, 10);

            if(x < 4)
            {
                if(newPosition.x + 1.32f > 2.1f)
                    newPosition.x -= 1.32f;
                else
                    newPosition.x += 1.32f;   
            }
            else if(x < 8)
            {
                if(newPosition.x - 1.32f < -4.1f)
                    newPosition.x += 1.32f;
                else
                    newPosition.x -= 1.32f;   
            }
            if(y < 4)
            {
                if(newPosition.y + 1.32f > 4.1f)
                    newPosition.y -= 1.32f;
                else
                    newPosition.y += 1.32f;
            }
            else if(y < 8)
            {
                if(newPosition.y - 1.32f < -4.1f)
                    newPosition.y += 1.32f;
                else
                    newPosition.y -= 1.32f;
            }

            float elapsedTime = 0f;
            float percentageComplete = 0;
            while(percentageComplete < 1)
            {
                print("here");
                elapsedTime += Time.deltaTime;
                percentageComplete = elapsedTime / duration;
                obj.transform.position = Vector3.Lerp(startPosition, newPosition, percentageComplete);
            }

        

            if(!xList.Contains(newPosition.x) && !yList.Contains(newPosition.y) && !x1List.Contains(newPosition.x) && !y1List.Contains(newPosition.y) )
            {
                obj.transform.position = newPosition;
                x1List.Add(newPosition.x);
                y1List.Add(newPosition.y);
            }
            if(clear)
            {
                if(!xList.Contains(newPosition.x) && !yList.Contains(newPosition.y))
            }


        }

        xList = x1List;
        yList = y1List;
    }*/


}

