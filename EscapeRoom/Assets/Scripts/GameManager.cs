using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool LightButtonPuzzleWon = false;
    public bool AnimalButtonPuzzleWon = false;
    public bool MazePuzzleWon = false;

    public GameObject greenLight1;
    public GameObject greenLight2;
    public GameObject greenLight3;

    public GameObject grayLight1;
    public GameObject grayLight2;
    public GameObject grayLight3;

    public GameObject exitDoorTrigger;

    public Animator doorAnim;

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
        }

        if (AnimalButtonPuzzleWon)
        {
            grayLight2.SetActive(false);
            greenLight2.SetActive(true);
        }

        if (MazePuzzleWon)
        {
            grayLight3.SetActive(false);
            greenLight3.SetActive(true);
        }

        if (LightButtonPuzzleWon && AnimalButtonPuzzleWon && MazePuzzleWon)
        {
            //OPEN THE DOOOR
            exitDoorTrigger.SetActive(true);
            doorAnim.SetBool("DoorOpen", true);
        }   
    }
}
