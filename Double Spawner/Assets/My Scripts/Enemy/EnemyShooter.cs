using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

    private float enemyShootTimer = 0;
    public float enemyFireRate = 1.0f;

    private float shootAnimationTimer = 0;
    public float shootAnimationRatio = 0.1f;

    public GameObject enemyObj;
    public GameObject gunObj;
    public GameObject myBullet;

    public GameObject bulletSPLeft;
    public GameObject bulletSPLeftFront;
    public GameObject bulletSPRightFront;
    public GameObject bulletSPRight;

    public bool isMotorbike = false;

    public AudioClip gunShot;

    public GameObject idleFrame;
    public GameObject shotFrame;   


    // Use this for initialization
    void Start ()
    {
        enemyShootTimer = enemyFireRate;

        //idleFrame = transform.GetChild(0).gameObject;
        //shotFrame = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update () {
        enemyShootTimer -= Time.deltaTime;
        shootAnimationTimer -= Time.deltaTime;

        if (enemyShootTimer <= 0)
        {
            if (isMotorbike)
            {
                Instantiate(myBullet, bulletSPLeft.transform.position, bulletSPLeft.transform.rotation);
                Instantiate(myBullet, bulletSPLeftFront.transform.position, bulletSPLeftFront.transform.rotation);
                Instantiate(myBullet, bulletSPRightFront.transform.position, bulletSPRightFront.transform.rotation);
                Instantiate(myBullet, bulletSPRight.transform.position, bulletSPRight.transform.rotation);
                enemyObj.GetComponent<EnemyTraits>().enemySpeed = -enemyObj.GetComponent<EnemyTraits>().unchangedEnemySpeed;
            }
            else
            {
                Instantiate(myBullet, transform.position, transform.rotation);
                enemyShootTimer = enemyFireRate;

                idleFrame.gameObject.SetActive(false);
                shotFrame.gameObject.SetActive(true);
                shootAnimationTimer = enemyFireRate*shootAnimationRatio;
            }
                        
            GameLoader.GameInstance.SFXSource.clip = gunShot;
            GameLoader.GameInstance.SFXSource.Play();
            enemyShootTimer = enemyFireRate;
        }

        if (shootAnimationTimer <= 0)
        {
            idleFrame.gameObject.SetActive(true);
            shotFrame.gameObject.SetActive(false);
        }
	}

}
