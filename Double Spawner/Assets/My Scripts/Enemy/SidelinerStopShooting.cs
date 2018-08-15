using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidelinerStopShooting : MonoBehaviour {

    public GameObject bulletSpawn1;
    public GameObject bulletSpawn2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "MotoActivator")
        {            
            bulletSpawn1.GetComponent<EnemyShooter>().enabled = false;
            bulletSpawn2.GetComponent<EnemyShooter>().enabled = false;
        }
    }
}
