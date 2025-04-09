using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    public bool start = false;
    // Update is called once per frame
    void Update()
    {
        if(start) 
        {
            remainingTime -= Time.deltaTime;
            int mins = Mathf.FloorToInt(remainingTime / 60);
            int secs = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", mins, secs);
        }
    }
}
