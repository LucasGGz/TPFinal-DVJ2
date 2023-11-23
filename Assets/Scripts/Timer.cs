using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timer;

    public float reimainingTime; //tiempo transcurrido
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (reimainingTime > 0)
        {
            reimainingTime -= Time.deltaTime;
        }
        else if (reimainingTime < 0)
        {
            reimainingTime = 0;
        }

        int minutes = Mathf.FloorToInt(reimainingTime / 60);
        int seconds = Mathf.FloorToInt(reimainingTime % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
