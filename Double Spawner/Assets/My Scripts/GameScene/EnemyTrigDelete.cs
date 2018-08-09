using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigDelete : MonoBehaviour {

    public float trigMoveSpeed = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(trigMoveSpeed, 0, 0);
	}

    private void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "Enemy" || collide.gameObject.tag == "SpikeTrap" || collide.gameObject.tag == "TriadBlock" || collide.gameObject.tag == "AlliedMafia")
        {
            Destroy (collide.gameObject);
        }
    }
}
