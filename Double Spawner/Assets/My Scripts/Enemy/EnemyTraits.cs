using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTraits : MonoBehaviour {
    public int enemyHealth = 5;
    public float enemySpeed = 0.1f;
    public int pointWorth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(enemySpeed, 0, 0);

        if (enemyHealth <= 0)
        {
            //Get scorecomponent of an object and add the pointWorth;
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.tag == "Bullet")
        {
            enemyHealth -= 1;
        }
    }
}
