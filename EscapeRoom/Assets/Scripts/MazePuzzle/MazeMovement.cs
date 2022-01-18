using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject startPos;
    public GameManager gameManager;
    public MazeButton mazeTransitioner;
    public AudioSource victorySound;

    public float speed = 12f;
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(-move * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            mazeTransitioner.TransitionMazeToPlayer();
        }
        if (Input.GetKey(KeyCode.R))
        {
            CharacterController cc = GetComponent(typeof(CharacterController)) as CharacterController;
            cc.enabled = false;
            this.transform.position = startPos.transform.position;
            cc.enabled = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MazeWall")
        {
            CharacterController cc = GetComponent(typeof(CharacterController)) as CharacterController;
            cc.enabled = false;
            this.transform.position = startPos.transform.position;
            cc.enabled = true;
            Debug.Log("Works");
        }
        if (other.gameObject.tag == "WinWall")
        {
            gameManager.MazePuzzleWon = true;
            mazeTransitioner.TransitionMazeToPlayer();
            victorySound.Play();
        }
    }
}