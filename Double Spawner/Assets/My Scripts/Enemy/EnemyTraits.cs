using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTraits : MonoBehaviour {
    public int enemyHealth = 5;
    public float enemySpeed = 0.1f;
    public int pointWorth;


    public GameObject tommyDrop;
    public GameObject shotgunDrop;
    private int dropWeapon;
    public int randomDropChance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(enemySpeed, 0, 0);

        if (enemyHealth <= 0)
        {
            //Get scorecomponent of an object and add the pointWorth;
            WeaponDrop();
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

    void WeaponDrop()
    {
        dropWeapon = Random.Range(1, randomDropChance);
        if (dropWeapon == 1)
        {
            Instantiate(tommyDrop, transform.position, transform.rotation);
        }
        if (dropWeapon == 2)
        {
            Instantiate(shotgunDrop, transform.position, transform.rotation);
        }
    }
}
