using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveMiniGame : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject currentTarget;
    private Vector3 screenCenter;
    private int actorMask;
    private int highlightMask;
    private bool valve1 = true;
    private bool valve2 = true;
    private bool valve3 = true;
    private bool valve4 = true;
    public int win = 5;
    public bool reset = false;

    public GameManager gameManager;
    public GameObject lightOff1;
    public GameObject lightOff2;
    public GameObject lightOff3;
    public GameObject lightOff4;
    public GameObject lightRed1;
    public GameObject lightRed2;
    public GameObject lightRed3;
    public GameObject lightRed4;

    public AudioSource valveSound;
    public AudioSource steamSound;
    public AudioSource victorySound;



    //public AudioSource buttonSound;

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
                if (target.gameObject.tag == "ValveButton")
                {
                    var tempObject = target.GetComponent<ButtonID>();

                    if(tempObject.Value == 1 && !valve1)
                    {
                        lightOff1.SetActive(true);
                        lightRed1.SetActive(false);
                        win += 1;
                        valve1 = true;
                    }

                    if (tempObject.Value == 2 && !valve2)
                    {
                        lightOff2.SetActive(true);
                        lightRed2.SetActive(false);
                        win += 1;
                        valve2 = true;
                    }

                    if (tempObject.Value == 3 && !valve3)
                    {
                        lightOff3.SetActive(true);
                        lightRed3.SetActive(false);
                        win += 1;
                        valve3 = true;
                    }

                    if (tempObject.Value == 4 && !valve4)
                    {
                        lightOff4.SetActive(true);
                        lightRed4.SetActive(false);
                        win += 1;
                        valve4 = true;
                    }

                    valveSound.Play();
                }
            }
        }

        if(win == 4)
        {
            victorySound.Play();
            win += 1;
        }

        if (reset)
        {
            lightOff1.SetActive(false);
            lightOff2.SetActive(false);
            lightOff3.SetActive(false);
            lightOff4.SetActive(false);
            lightRed1.SetActive(true);
            lightRed2.SetActive(true);
            lightRed3.SetActive(true);
            lightRed4.SetActive(true);
            valve1 = false;
            valve2 = false;
            valve3 = false;
            valve4 = false;
            steamSound.Play();
            win = 0;
            reset = false;
        }
    }
    
}