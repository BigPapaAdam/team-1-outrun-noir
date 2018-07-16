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

    private void OnCollisionStay(Collision collide)
    {
        Debug.Log("has collided");
        if (collide.gameObject.tag == "Enemy")
        {
            Debug.Log("is enemy");
            Destroy (collide.gameObject);
        }
    }
}
