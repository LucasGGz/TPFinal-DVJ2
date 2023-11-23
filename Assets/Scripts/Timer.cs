using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timer;

    public float remainingTime; // tiempo transcurrido

    public bool isInitialized = false;
    private float initializationTime = 7f;

    void Update()
    {
        if (!isInitialized)
        {
            initializationTime -= Time.deltaTime;
            if (initializationTime <= 0)
            {
                isInitialized = true;
                remainingTime = 30f;
            }
        }
        
        if (isInitialized && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}