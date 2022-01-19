using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public float MaxTime = 18;
    private float timer;
    private int RandomEvent;

    public float wireCountdown = 10;
    public float valveCountdown = 10;

    public GameObject gameManager;
    public GameObject countdownMinigame;
    public GameObject countdownMinigame2;
    public GameObject countdownMinigameValve;

    void Start()
    {
        
    }

    void Update()
    {
        //WireMiniGame
        if(gameManager.GetComponent<WireGame1>().win > 3 && gameManager.GetComponent<WireGame2>().win > 3 /*&& gameManager.GetComponent<ValveMiniGame>().win > 3*/)
        {
            countdownMinigame.GetComponent<MiniGameTimer>().timeValue = 0;

            countdownMinigame2.GetComponent<MiniGameTimer>().timeValue = 0;

            //countdownMinigameValve.GetComponent<MiniGameTimer>().timeValue = 0;

            countdownMinigame.GetComponent<MiniGameTimer>().isDone = true;

            countdownMinigame2.GetComponent<MiniGameTimer>().isDone = true;

            //countdownMinigameValve.GetComponent<MiniGameTimer>().isDone = true;

            timer += Time.deltaTime;
        }

        if(timer >= MaxTime)
        {
            RandomEvent = Random.Range(0, 2);
            switch (RandomEvent)
            {
                case 0:
                    gameManager.GetComponent<WireGame1>().reset = true;
                    countdownMinigame.GetComponent<MiniGameTimer>().timeValue = wireCountdown;
                    break;

                case 1:
                    gameManager.GetComponent<WireGame2>().reset = true;
                    countdownMinigame2.GetComponent<MiniGameTimer>().timeValue = wireCountdown;
                    break;

                /*case 2:
                    gameManager.GetComponent<ValveMiniGame>().reset = true;
                    countdownMinigameValve.GetComponent<MiniGameTimer>().timeValue = valveCountdown;
                    break;*/
            }
            timer = 0;
        }

        //ValveMiniGame



    } 
}
