using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeButton : MonoBehaviour
{
    public bool IsMazeButton = true;
    public GameObject Player;
    public GameObject MazePlayer;
    public Camera cam;
    public Camera mazeCam;
    public void TransitionPlayerToMaze()
    {
        Player.gameObject.SetActive(false);
        MazePlayer.gameObject.SetActive(true);
        cam.gameObject.SetActive(false);
        mazeCam.gameObject.SetActive(true);
    }
    public void TransitionMazeToPlayer()
    {
        Player.gameObject.SetActive(true);
        MazePlayer.gameObject.SetActive(false);
        cam.gameObject.SetActive(true);
        mazeCam.gameObject.SetActive(false);
    }
}
