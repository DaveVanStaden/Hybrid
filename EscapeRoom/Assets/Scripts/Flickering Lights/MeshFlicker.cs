using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshFlicker : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;

    private float timeRange = 0.45f;

    // Update is called once per frame
    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickeringMesh());
        }
    }

    IEnumerator FlickeringMesh()
    {
        isFlickering = true;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        timeDelay = Random.Range(timeRange, timeRange);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        timeDelay = Random.Range(timeRange, timeRange);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
