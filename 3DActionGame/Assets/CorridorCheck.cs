using UnityEngine;
using System.Collections;

public class CorridorCheck : MonoBehaviour {
    public bool isInCorridor = false;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Corridor")
        {
            Debug.Log("ayy");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Corridor")
        {
            isInCorridor = false;
        }
    }
}
