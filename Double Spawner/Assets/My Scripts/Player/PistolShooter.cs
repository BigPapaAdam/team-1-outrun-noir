using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShooter : MonoBehaviour {

    public float pistolRate = 1.0f;
    private float timeOfShot = 0.0f;

    public GameObject playerObj;
    public GameObject pistolObj;
    public GameObject tommyObj;
    public GameObject shotgunObj;
    public GameObject SoundManager;
    public AudioSource SFXSource;

    public GameObject myBullet;


    public AudioSource aSource;
    public AudioClip pistolShot;
    // Use this for initialization
    void Start () {
        SoundManager = GameObject.Find("SoundManager");
        SFXSource = SoundManager.transform.GetChild(1).GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        pistolObj.SetActive(true);
        tommyObj.SetActive(false);
        shotgunObj.SetActive(false);

        PistolFire();
    }

    void PistolFire()
    {
        if (Input.GetKey(GameLoader.GameInstance.CharacterShoot))
        {
            if (Time.time > timeOfShot + pistolRate)
            {
                Instantiate(myBullet, transform.position, transform.rotation);
                SFXSource.PlayOneShot(pistolShot);
                timeOfShot = Time.time;
            }
        }
    }

}
