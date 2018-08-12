using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneDetection : MonoBehaviour {

    public bool motoSpawnable = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider collide)
    {
        if (collide.gameObject.tag == "Enemy" || collide.gameObject.tag == "SpikeTrap" || collide.gameObject.tag == "TriadBlock")
        {
            motoSpawnable = false;
        }        
    }

    private void OnTriggerExit(Collider collide)
    {
        motoSpawnable = true;
    }

}
