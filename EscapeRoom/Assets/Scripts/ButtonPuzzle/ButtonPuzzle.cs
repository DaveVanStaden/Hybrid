using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject currentTarget;
    private Vector3 screenCenter;
    private int actorMask;
    private int highlightMask;
    public int puzzleSum;
    public int totalUsedButtons;
    private bool setWin = false;

    public GameManager gameManager;

    public Animator Green;
    public Animator Blue;
    public Animator Red;
    public Animator Red2;
    public Animator Yellow;

    public AudioSource buttonSound;
    public AudioSource victorySound;

    private void Awake()
    {
        screenCenter = new Vector3(Screen.width >> 1, Screen.height >> 1);
        actorMask = LayerMask.NameToLayer("Actor");
        highlightMask = LayerMask.NameToLayer("Highlight");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            //totalUsedButtons = 0;
            //puzzleSum = 0;
        }
        RaycastHit info;
        if (Physics.Raycast(playerCamera.ScreenPointToRay(screenCenter), out info, 10000, LayerMask.GetMask("Actor", "Highlight")))
        {
            GameObject target = info.collider.gameObject;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (target.gameObject.tag == "Interactible")
                {
                    var tempObject = target.GetComponent<ButtonID>();
                    puzzleSum += tempObject.Value;
                    totalUsedButtons += 1;
                    print(puzzleSum);
                    buttonSound.Play();
                }

                if (target.gameObject.tag == "ResetButton")
                {
                    var tempObject = target.GetComponent<ButtonID>();
                    puzzleSum += tempObject.Value;
                    totalUsedButtons = 0;
                    puzzleSum = 0;
                    buttonSound.Play();
                }
            }
        }

        if(totalUsedButtons == 10 && puzzleSum == 34)
        {
            totalUsedButtons = 0;
            puzzleSum = 0;
            setWin = true;
            gameManager.LightButtonPuzzleWon = true;
            Debug.Log("Win");
            victorySound.Play();
        } else if (totalUsedButtons == 10 && puzzleSum != 34)
        {
            totalUsedButtons = 0;
            puzzleSum = 0;
            Debug.Log("Lose");
        }
        AnimMapping();
    }

    void AnimMapping()
    {
        Green.SetBool("ButtonPressed", setWin);
        Blue.SetBool("ButtonPressed", setWin);
        Red.SetBool("ButtonPressed", setWin);
        Red2.SetBool("ButtonPressed", setWin);
        Yellow.SetBool("ButtonPressed", setWin);
    }
}
