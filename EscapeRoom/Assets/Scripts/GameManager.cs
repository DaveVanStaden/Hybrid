using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool LightButtonPuzzleWon = false;
    public bool AnimalButtonPuzzleWon = false;
    public bool MazePuzzleWon = false;
    [SerializeField] private ButtonPuzzle buttonPuzzle;
    [SerializeField] private MemoryPuzzle memoryPuzzle;
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
            buttonPuzzle.enabled = false;
        }
        if (AnimalButtonPuzzleWon)
        {
            memoryPuzzle.enabled = false;
        }
        if (LightButtonPuzzleWon && AnimalButtonPuzzleWon && MazePuzzleWon)
        {

        }   
    }
}
