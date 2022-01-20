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

    public AudioSource errorSound;

    public bool isDone = true;
    public bool wireGame = false;
    public bool valveGame = false;

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

            errorSound.Play();

            if (valveGame)
            {
                timeValue = gameManager.GetComponent<MiniGameManager>().valveCountdown;
            }
            if (wireGame)
            {
                timeValue = gameManager.GetComponent<MiniGameManager>().wireCountdown;
            }

            isDone = true;

            StartCoroutine(ChangeColor());
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
    IEnumerator ChangeColor()
    {
            timerText.GetComponent<Text>().color = Color.red;

            yield return new WaitForSeconds(1);

            timerText.GetComponent<Text>().color = Color.white;
    }
}