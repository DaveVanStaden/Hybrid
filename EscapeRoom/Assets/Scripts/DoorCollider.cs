using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    public GameObject endUI;
    public GameObject escaped;

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){
            endUI.SetActive(true);
            escaped.SetActive(true);
            StartCoroutine(ExitApplication());
        }
    }

    IEnumerator ExitApplication()
    {
            yield return new WaitForSeconds(5);

            Application.Quit();
    }

}
