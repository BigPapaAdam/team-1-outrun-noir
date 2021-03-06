﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupManager : MonoBehaviour {

    private float pickupTimer;
    public float pickupDuration;
    public GameObject bulletSpawn;
    //public Sprite[] Sprites;
    public Sprite[] Sprites;
    public GameObject CanvasObject;

    public bool hasPickup;

    public AudioClip tommyPickupAudio;
    public AudioClip shotgunPickupAudio;
    public AudioClip revertToPistolAudio;




    // Use this for initialization
    void Start () {

        CanvasObject = GameObject.Find("Canvas");
        CanvasObject.transform.GetChild(3).transform.GetChild(4).GetComponent<Image>().sprite = Sprites[0];
        pickupTimer = pickupDuration;
        bulletSpawn.GetComponent<PistolShooter>().enabled = true;
        bulletSpawn.GetComponent<TommyShooter>().enabled = false;
        bulletSpawn.GetComponent<ShotgunShooter>().enabled = false;
        hasPickup = false;

    }

    // Update is called once per frame
    void Update () {
        pickupTimer -= Time.deltaTime;
        if (pickupTimer <= 0)
        {
            CanvasObject.transform.GetChild(3).transform.GetChild(4).GetComponent<Image>().sprite = Sprites[0];
            bulletSpawn.GetComponent<PistolShooter>().enabled = true;
            bulletSpawn.GetComponent<TommyShooter>().enabled = false;
            bulletSpawn.GetComponent<ShotgunShooter>().enabled = false;
            GetComponent<PlayerAttributes>().weaponTimerUI.gameObject.SetActive(false);

            GameLoader.GameInstance.SFXSource.PlayOneShot(revertToPistolAudio);

            hasPickup = false;
        }
        else
        {
            GetComponent<PlayerAttributes>().weaponTimerUI.text = pickupTimer.ToString("0.0");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TommyPickup"))
        {
            bulletSpawn.GetComponent<PistolShooter>().enabled = false;
            bulletSpawn.GetComponent<TommyShooter>().enabled = true;
            bulletSpawn.GetComponent<ShotgunShooter>().enabled = false;
            CanvasObject.transform.GetChild(3).transform.GetChild(4).GetComponent<Image>().sprite = Sprites[1];

            pickupTimer = pickupDuration;

            GetComponent<PlayerAttributes>().weaponTimerUI.gameObject.SetActive(true);
            GetComponent<PlayerAttributes>().weaponTimerUI.text = pickupTimer.ToString();

            Destroy(other.gameObject);
            GameLoader.GameInstance.SFXSource.PlayOneShot(tommyPickupAudio);

            hasPickup = true;
        }

        if (other.gameObject.CompareTag("ShotgunPickup"))
        {
            bulletSpawn.GetComponent<PistolShooter>().enabled = false;
            bulletSpawn.GetComponent<TommyShooter>().enabled = false;
            bulletSpawn.GetComponent<ShotgunShooter>().enabled = true;
            CanvasObject.transform.GetChild(3).transform.GetChild(4).GetComponent<Image>().sprite = Sprites[2];
            pickupTimer = pickupDuration;

            GetComponent<PlayerAttributes>().weaponTimerUI.gameObject.SetActive(true);
            GetComponent<PlayerAttributes>().weaponTimerUI.text = pickupTimer.ToString();

            Destroy(other.gameObject);
            GameLoader.GameInstance.SFXSource.PlayOneShot(shotgunPickupAudio);

            hasPickup = true;


        }
    }
}
