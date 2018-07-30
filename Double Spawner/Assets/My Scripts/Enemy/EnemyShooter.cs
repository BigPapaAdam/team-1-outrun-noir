using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

    public float enemyRate = 1.0f;
    private float timeOfShot = 0.0f;

    public GameObject enemyObj;
    public GameObject gunObj;
    public GameObject myBullet;

    public AudioSource aSource;
    public AudioClip gunShot;


    // Use this for initialization
    void Start () {
        aSource = enemyObj.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    void PistolFire()
    {
        if (Time.time > timeOfShot + enemyRate)
        {
            Instantiate(myBullet, transform.position, transform.rotation);
            aSource.PlayOneShot(gunShot);
            timeOfShot = Time.time;
        }
        
    }
}
