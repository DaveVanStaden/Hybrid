using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool LightButtonPuzzleWon = false;
    public bool AnimalButtonPuzzleWon = false;
    public bool MazePuzzleWon = false;
    public bool alreadyPlayed = false;

    public GameObject greenLight1;
    public GameObject greenLight2;
    public GameObject greenLight3;

    public GameObject grayLight1;
    public GameObject grayLight2;
    public GameObject grayLight3;

    //LGHTS ABOVE PUZZLES
    public GameObject greenLight4;
    public GameObject grayLight4;
    public GameObject greenLight5;
    public GameObject grayLight5;
    public GameObject greenLight6;
    public GameObject grayLight6;


    public GameObject exitDoorTrigger;

    public Animator doorAnim;

    public AudioSource doorSound;

    void Start()
    {
        LightButtonPuzzleWon = false;
        AnimalButtonPuzzleWon = false;
        MazePuzzleWon = false;
}

    // Update is called once per frame
    void Update()
    {
        if (LightButtonPuzzleWon)
        {
            grayLight1.SetActive(false);
            greenLight1.SetActive(true);
            grayLight5.SetActive(false);
            greenLight5.SetActive(true);
        }

        if (AnimalButtonPuzzleWon)
        {
            grayLight2.SetActive(false);
            greenLight2.SetActive(true);
            grayLight4.SetActive(false);
            greenLight4.SetActive(true);
        }

        if (MazePuzzleWon)
        {
            grayLight3.SetActive(false);
            greenLight3.SetActive(true);
            grayLight6.SetActive(false);
            greenLight6.SetActive(true);
        }

        if (LightButtonPuzzleWon && AnimalButtonPuzzleWon && MazePuzzleWon)
        {
            //OPEN THE DOOOR
            exitDoorTrigger.SetActive(true);
            doorAnim.SetBool("DoorOpen", true);

            if (!alreadyPlayed)
                {
                    doorSound.Play();
                    alreadyPlayed = true;
                }
        }

    }
}
