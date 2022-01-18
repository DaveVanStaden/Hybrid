using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPuzzle : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject currentTarget;
    public int[] puzzleArray;
    private int arrayLocation = 0;
    private Vector3 screenCenter;
    private int actorMask;
    private int highlightMask;
    public GameManager gameManager;
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
            arrayLocation = 0;
        }
        RaycastHit info;
        if (Physics.Raycast(playerCamera.ScreenPointToRay(screenCenter), out info, 10000, LayerMask.GetMask("Actor", "Highlight")))
        {
            GameObject target = info.collider.gameObject;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (target.gameObject.tag == "Interactible")
                {
                    var tempObject = target.GetComponent<MemoryButtonID>();
                    if(tempObject.Value == puzzleArray[arrayLocation])
                    {
                        arrayLocation += 1;
                        Debug.Log("it works");
                    }
                    else
                    {
                        Debug.Log("Wrong");
                        arrayLocation = 0;
                    }
                }
            }
        }
        if(arrayLocation >= puzzleArray.Length)
        {
            arrayLocation = 0;
            gameManager.AnimalButtonPuzzleWon = true;
            Debug.Log("win");
        }
           
    }
}
