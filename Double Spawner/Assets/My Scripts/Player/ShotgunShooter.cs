using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShooter : MonoBehaviour {

    public float shotgunRate = 0.2f;
    private float timeOfShot = 0.0f;

    public GameObject playerObj;
    public GameObject pistolObj;
    public GameObject tommyObj;
    public GameObject shotgunObj;
    public GameObject myBullet;


    public AudioSource aSource;
    public AudioClip shotgunShot;

    // Use this for initialization
    void Start () {
        aSource = playerObj.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        pistolObj.SetActive(false);
        tommyObj.SetActive(false);
        shotgunObj.SetActive(true);

        ShotgunFire();
    }

    void ShotgunFire()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > timeOfShot + shotgunRate)
            {
                aSource.PlayOneShot(shotgunShot);
                Instantiate(myBullet, transform.position, transform.rotation);
                timeOfShot = Time.time;
            }
        }
    }
}
