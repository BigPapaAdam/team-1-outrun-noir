﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TommyShooter : MonoBehaviour {

    public float tommyRate = 0.5f;
    private float timeOfShot = 0.0f;

    public GameObject playerObj;
    public GameObject pistolObj;
    public GameObject tommyObj;
    public GameObject shotgunObj;
    public GameObject myBullet;
    //public GameObject SoundManager;

    //public AudioSource SFXSource;
    public AudioClip tommyShot;

    // Use this for initialization
    void Start () {
        //SoundManager = GameObject.Find("SoundManager");
        //SFXSource = SoundManager.transform.GetChild(1).GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update () {
        pistolObj.SetActive(false);
        tommyObj.SetActive(true);
        shotgunObj.SetActive(false);

        TommyFire();

    }

    void TommyFire()
    {
        if (Input.GetKey(GameLoader.GameInstance.CharacterShoot))
        {
            if (Time.time > timeOfShot + tommyRate)
            {
                Instantiate(myBullet, transform.position, transform.rotation);
                GameLoader.GameInstance.SFXSource.clip = tommyShot;
                GameLoader.GameInstance.SFXSource.Play();
                //SFXSource.PlayOneShot(tommyShot);
                timeOfShot = Time.time;
            }
        }
    }
}
