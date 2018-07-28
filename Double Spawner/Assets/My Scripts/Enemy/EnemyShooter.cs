using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

    private float enemyShootTimer = 0;
    public float enemyFireRate = 1.0f;

    public GameObject enemyObj;
    public GameObject gunObj;
    public GameObject myBullet;

    public AudioSource aSource;
    public AudioClip gunShot;


    // Use this for initialization
    void Start () {
        aSource = enemyObj.GetComponent<AudioSource>();

        enemyShootTimer = enemyFireRate;

    }

    // Update is called once per frame
    void Update () {
        enemyShootTimer -= Time.deltaTime;
        if (enemyShootTimer <= 0)
        {
            Instantiate(myBullet, transform.position, transform.rotation);
            aSource.PlayOneShot(gunShot);
            enemyShootTimer = enemyFireRate;
        }
	}

    void PistolFire()
    {
        //if (Time.time > timeOfShot + enemyRate)
        //{
        //    Instantiate(myBullet, transform.position, transform.rotation);
        //    aSource.PlayOneShot(gunShot);
        //    timeOfShot = Time.time;
        //}
        
    }
}
