using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedLightTestScript : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    private Vector3 screenCenter;
    private int actorMask;
    private int highlightMask;
    private bool buttonPressed = false;

    public Animator Green;
    public Animator Blue;
    public Animator Red;
    public Animator Yellow;


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
                    buttonPressed = !buttonPressed;
                    Debug.Log("Turn off");
                }
            }
        }

        AnimMapping();
    }

    void AnimMapping()
    {
        Green.SetBool("ButtonPressed", buttonPressed);
        Blue.SetBool("ButtonPressed", buttonPressed);
        Red.SetBool("ButtonPressed", buttonPressed);
        Yellow.SetBool("ButtonPressed", buttonPressed);
    }
}
