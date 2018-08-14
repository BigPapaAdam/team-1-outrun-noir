using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShooter : MonoBehaviour {

    public float pistolRate = 1.0f;
    private float timeOfShot = 0.0f;

    private float shootAnimationTimer = 0;
    public float shootAnimationRatio = 0.1f;

    public GameObject playerObj;
    public GameObject pistolObj;
    public GameObject tommyObj;
    public GameObject shotgunObj;
    //public GameObject SoundManager;
    //public AudioSource SFXSource;

    public GameObject myBullet;

    public AudioClip pistolShot;

    public GameObject idleFrame;
    public GameObject shotFrame;

    // Use this for initialization
    void Start ()
    {
        //idleFrame = transform.GetChild(0).gameObject;
        //shotFrame = transform.GetChild(1).gameObject;

        //SoundManager = GameObject.Find("SoundManager");
        //SFXSource = SoundManager.transform.GetChild(1).GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        pistolObj.SetActive(true);
        tommyObj.SetActive(false);
        shotgunObj.SetActive(false);

        shootAnimationTimer -= Time.deltaTime;

        PistolFire();
    }

    void PistolFire()
    {
        if (Input.GetKey(GameLoader.GameInstance.CharacterShoot))
        {
            if (Time.time > timeOfShot + pistolRate)
            {
                Instantiate(myBullet, transform.position, transform.rotation);
                GameLoader.GameInstance.SFXSource.clip = pistolShot;
                GameLoader.GameInstance.SFXSource.Play();
                //SFXSource.PlayOneShot(pistolShot);
                timeOfShot = Time.time;

                idleFrame.gameObject.SetActive(false);
                shotFrame.gameObject.SetActive(true);
                shootAnimationTimer = pistolRate * shootAnimationRatio;
            }
        }

        if (shootAnimationTimer <= 0)
        {
            idleFrame.gameObject.SetActive(true);
            shotFrame.gameObject.SetActive(false);
        }
    }

}
