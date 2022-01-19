using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireGame2 : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject currentTarget;
    private Vector3 screenCenter;
    private int actorMask;
    private int highlightMask;
    private int buttonsPressed = 0;
    private int buttonCombo = 0;
    public int win = 5;
    private bool wire1 = true;
    private bool wire2 = true;
    private bool wire3 = true;
    private bool wire4 = true;

    public bool reset = false;
    public GameObject openWire1;
    public GameObject openWire2;
    public GameObject openWire3;
    public GameObject openWire4;
    public GameObject closedWire1;
    public GameObject closedWire2;
    public GameObject closedWire3;
    public GameObject closedWire4;
    public AudioSource buttonSound;
    public AudioSource victorySound;
    public AudioSource electricSound;
    public AudioSource deactivateSound;

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
                        buttonCombo += tempObject.Value;
                        buttonsPressed += 1;
                        buttonSound.Play();
                        if(tempObject.Value == 69)
                        {
                            reset = true;
                        }
                    }
                }
            }

            if (buttonCombo == 41 && !wire1)
            {
                closedWire1.SetActive(true);
                openWire1.SetActive(false);
                electricSound.Play();
                win += 1;
                wire1 = true;
            }

            if (buttonCombo == 12 && !wire2)
            {
                closedWire2.SetActive(true);
                openWire2.SetActive(false);
                electricSound.Play();
                win += 1;
                wire2 = true;
            }

            if (buttonCombo == 33 && !wire3)
            {
                closedWire3.SetActive(true);
                openWire3.SetActive(false);
                electricSound.Play();
                win += 1;
                wire3 = true;
            }

            if (buttonCombo == 24 && !wire4)
            {
                closedWire4.SetActive(true);
                openWire4.SetActive(false);
                electricSound.Play();
                win += 1;
                wire4 = true;
            }

            if (buttonsPressed == 2)
            {
                buttonCombo = 0;
                buttonsPressed = 0;
            }
       
        if(win == 4)
        {
            Debug.Log("Win");
            victorySound.Play();
            win += 1;
        }

        if (reset)
        {
            closedWire1.SetActive(false);
            closedWire2.SetActive(false);
            closedWire3.SetActive(false);
            closedWire4.SetActive(false);
            openWire1.SetActive(true);
            openWire2.SetActive(true);
            openWire3.SetActive(true);
            openWire4.SetActive(true);
            wire1 = false;
            wire2 = false;
            wire3 = false;
            wire4 = false;
            buttonCombo = 0;
            buttonsPressed = 0;
            deactivateSound.Play();
            win = 0;
            reset = false;
        }
    }
}
