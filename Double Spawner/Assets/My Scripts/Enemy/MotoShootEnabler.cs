using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoShootEnabler : MonoBehaviour {

    public GameObject bulletSpawn;

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
            GetComponent<EnemyTraits>().enemySpeed = 0;
            bulletSpawn.GetComponent<EnemyShooter>().enabled = true;
        }
    }

    //private void OnTriggerExit(Collider collide)
    //{
    //    if (collide.gameObject.tag == "MotoActivator")
    //    {
    //        bulletSpawn.GetComponent<EnemyShooter>().enabled = false;
    //    }
    //}
}
