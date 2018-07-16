using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTraits : MonoBehaviour {
    public int enemyHealth = 5;
    public float enemySpeed = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(enemySpeed, 0, 0);
    }

    public void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.tag == "Bullet")
        {
            enemyHealth -= 1;
        }
    }
}
