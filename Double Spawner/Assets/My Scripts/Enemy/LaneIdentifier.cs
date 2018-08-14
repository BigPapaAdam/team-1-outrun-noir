using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneIdentifier : MonoBehaviour {

    public GameObject face;
    public GameObject back;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "pathBot")
        {
            face.gameObject.SetActive(false);
            back.gameObject.SetActive(true);
        }

        if (other.gameObject.tag == "pathTop")
        {
            face.gameObject.SetActive(true);
            back.gameObject.SetActive(false);
        }
    }
}
