using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float timeValue = 60;
    public Text timeText;

    void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            Application.Quit();
            EditorApplication.isPlaying = false;
        }
        Displaytime(timeValue);
    }

    void Displaytime(float timeToDisplay) 
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0 && timeValue >= 60)
        {
            timeToDisplay += 1;
        }

        if (timeValue >= 60)
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        } else
        {
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            float miliseconds = timeToDisplay % 1 * 100;
            timeText.text = string.Format("{0:00}:{1:00}", seconds, miliseconds);
        }
    }
}
