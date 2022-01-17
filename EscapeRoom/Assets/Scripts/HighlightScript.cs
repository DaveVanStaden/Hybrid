using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightScript : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject currentTarget;
    private Vector3 screenCenter;
    private int actorMask;
    private int highlightMask;
    private void Awake()
    {
        screenCenter = new Vector3(Screen.width >> 1, Screen.height >> 1);
        actorMask = LayerMask.NameToLayer("Actor");
        highlightMask = LayerMask.NameToLayer("Highlight");
    }
    void Update()
    {
        RaycastHit info;
        if(Physics.Raycast(playerCamera.ScreenPointToRay(screenCenter),out info, 10000, LayerMask.GetMask("Actor","Highlight")))
        {
            GameObject target = info.collider.gameObject;
            if(target.gameObject.tag == "Interactible")
            {
                if (currentTarget != target)
                {
                    currentTarget = target;
                    currentTarget.layer = highlightMask;
                }
            }
        }
        else if(currentTarget != null)
        {
            currentTarget.layer = actorMask;
            currentTarget = null;
        }
    }
}
