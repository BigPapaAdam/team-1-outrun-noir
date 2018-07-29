using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

    public float enemyRate = 1.0f;
    private float timeOfShot = 0.0f;

    public GameObject enemyObj;
    public GameObject gunObj;
    public GameObject myBullet;
    //variable added by Gordon
    public GameObject playerObj;

    public AudioSource aSource;
    public AudioClip gunShot;


    // Use this for initialization
    void Start () {
        aSource = enemyObj.GetComponent<AudioSource>();
        //call for variable added by Gordon
        playerObj = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update ()
    {
        // new code added by gordon------------------------------------------------
        // code to test the enemy shooting
        if (Time.time > timeOfShot + enemyRate)
        {
            Instantiate(myBullet, transform.position, transform.rotation);
            aSource.PlayOneShot(gunShot);
            timeOfShot = Time.time;
        }
        //end code added by Gordon--------------------------------------------------
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
