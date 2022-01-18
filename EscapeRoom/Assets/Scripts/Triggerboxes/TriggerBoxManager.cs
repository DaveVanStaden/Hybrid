using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxManager : MonoBehaviour
{
        void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "LedButtonCollider")
            {
                var tempObject = GetComponent<ButtonPuzzle>();
                tempObject.enabled = true;
            }

            if(other.gameObject.tag == "KPKCollider")
            {
                var tempObjectB = GetComponent<MemoryPuzzle>();
                tempObjectB.enabled = true;
            }

            if(other.gameObject.tag == "MazeCollider")
            {
                var tempObjectC = GetComponent<MazeTransition>();
                tempObjectC.enabled = true;
            }
            
        }

        void OnTriggerExit(Collider other)
        {
            var tempObject = GetComponent<ButtonPuzzle>();
            tempObject.enabled = false;

            var tempObjectB = GetComponent<MemoryPuzzle>();
            tempObjectB.enabled = false;

            var tempObjectC = GetComponent<MazeTransition>();
            tempObjectC.enabled = false;
        }
}
