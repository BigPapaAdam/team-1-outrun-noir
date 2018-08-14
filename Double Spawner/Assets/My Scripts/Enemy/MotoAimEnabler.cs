using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoAimEnabler : MonoBehaviour {

    public GameObject idleFrame;
    public GameObject shotFrame;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MotoAimActivator")
        {
            idleFrame.gameObject.SetActive(false);
            shotFrame.gameObject.SetActive(true);
        }        
    }

    private void OnTriggerExit(Collider collide)
    {
        idleFrame.gameObject.SetActive(true);
        shotFrame.gameObject.SetActive(false);
    }
}
