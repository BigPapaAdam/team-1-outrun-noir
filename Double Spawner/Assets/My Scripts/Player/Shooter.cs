using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject myBullet;



    //public GameObject myFastShot;
    public float pistolRate = 1.0f;
    public float tommyRate = 0.5f;
    public float shotgunRate = 0.2f;

    private float timeOfShot = 0.0f;

    private string currentWeapon = "Pistol";

    public GameObject playerObj;

    public GameObject pistolObj;
    public GameObject tommyObj;
    public GameObject shotgunObj;

    public AudioSource aSource;
    public AudioClip pistolShot;
    public AudioClip tommyShot;
    public AudioClip shotgunShot;

	// Use this for initialization
	void Start () {
        aSource = playerObj.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
       

        //if (playerObj.GetComponent<GunPickup>().currentWeapon == "Pistol")
        //{
            PistolFire();
    //    pistolObj.SetActive(true);
    //    tommyObj.SetActive(false);
    //    shotgunObj.SetActive(false);

    //}

    //if (playerObj.GetComponent<GunPickup>().currentWeapon == "Heatseeker")
    //{
    //    TommyFire();
    //    pistolObj.SetActive(false);
    //    tommyObj.SetActive(true);
    //    shotgunObj.SetActive(false);
    //}

    //if (playerObj.GetComponent<GunPickup>().currentWeapon == "Minigun")
    //{
    //    ShotgunFire();
    //    pistolObj.SetActive(false);
    //    tommyObj.SetActive(false);
    //    shotgunObj.SetActive(true);
    //}
}

    



    void PistolFire()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > timeOfShot + pistolRate)
            {
                Instantiate(myBullet, transform.position, transform.rotation);
                aSource.PlayOneShot(pistolShot);
                timeOfShot = Time.time;
            }
        }
    }

    void TommyFire()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > timeOfShot + tommyRate)
            {
                Instantiate(myBullet, transform.position, transform.rotation);
                aSource.PlayOneShot(tommyShot);
                timeOfShot = Time.time;
            }
        }
    }

    void ShotgunFire()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > timeOfShot + shotgunRate)
            {
                aSource.PlayOneShot(shotgunShot );
                Instantiate(myBullet, transform.position, transform.rotation);
                timeOfShot = Time.time;
            }
        }
    }
}
