using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    private float MaxTime = 18;
    private float timer;
    private int RandomEvent;

    private float MaxTime2 = 12;
    private float timer2;
    private int RandomEvent2;

    public GameObject gameManager;

    void Start()
    {
        
    }

    void Update()
    {
        //WireMiniGame
        if(gameManager.GetComponent<WireGame1>().win >= 3 && gameManager.GetComponent<WireGame2>().win >= 3)
        {
            timer += Time.deltaTime;
        }

        if(timer >= MaxTime)
        {
            RandomEvent = Random.Range(0, 4);
            switch (RandomEvent)
            {
                case 1:
                    gameManager.GetComponent<WireGame1>().reset = true;
                    break;

                default:
                    gameManager.GetComponent<WireGame2>().reset = true;
                    break;
            }
            timer = 0;
        }

        //ValveMiniGame
        timer2 += Time.deltaTime;
        if(timer >= MaxTime2)
        {
            RandomEvent = Random.Range(0, 4);
            switch (RandomEvent2)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            timer2 = 0;
        }





    } 
}
