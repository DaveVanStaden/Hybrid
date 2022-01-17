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
    private int puzzleSum;
    private int totalUsedButtons;
    private void Awake()
    {
        screenCenter = new Vector3(Screen.width >> 1, Screen.height >> 1);
        actorMask = LayerMask.NameToLayer("Actor");
        highlightMask = LayerMask.NameToLayer("Highlight");
    }

    void Update()
    {
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
                }
            }
        }

        if(totalUsedButtons == 10 && puzzleSum == 34)
        {
            totalUsedButtons = 0;
            puzzleSum = 0;
            Debug.Log("Win");
        } else if (totalUsedButtons == 10 && puzzleSum != 34)
        {
            totalUsedButtons = 0;
            puzzleSum = 0;
            Debug.Log("Lose");
        }
    }
}
