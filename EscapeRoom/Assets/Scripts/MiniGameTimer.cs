using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameTimer : MonoBehaviour
{
    public float timeValue = 0;
    public TextMesh timeText;
    public GameObject timerText;
    public GameObject gameManager;

    public bool isDone = true;

    public float failTimeRemove = 60;

    void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            isDone = false;
        }
        else
        {
            timeValue = 0;

            //REMOVE CERTAIN TIME
        }
        if (timeValue == 0 && !isDone)
        {
            timerText.GetComponent<CountdownTimer>().timeValue -= failTimeRemove;
            
            timeValue = gameManager.GetComponent<MiniGameManager>().wireCountdown;

            isDone = true;
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
