using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour {

    private float pickupTimer;
    public float pickupDuration;
    public GameObject bulletSpawn;

	// Use this for initialization
	void Start () {
        pickupTimer = pickupDuration;
        bulletSpawn.GetComponent<PistolShooter>().enabled = true;
        bulletSpawn.GetComponent<TommyShooter>().enabled = false;
        bulletSpawn.GetComponent<ShotgunShooter>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        pickupTimer -= Time.deltaTime;
        if (pickupTimer <= 0)
        {
            bulletSpawn.GetComponent<PistolShooter>().enabled = true;
            bulletSpawn.GetComponent<TommyShooter>().enabled = false;
            bulletSpawn.GetComponent<ShotgunShooter>().enabled = false;


        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TommyPickup"))
        {
            bulletSpawn.GetComponent<PistolShooter>().enabled = false;
            bulletSpawn.GetComponent<TommyShooter>().enabled = true;
            bulletSpawn.GetComponent<ShotgunShooter>().enabled = false;
            pickupTimer = pickupDuration;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("ShotgunPickup"))
        {
            bulletSpawn.GetComponent<PistolShooter>().enabled = false;
            bulletSpawn.GetComponent<TommyShooter>().enabled = false;
            bulletSpawn.GetComponent<ShotgunShooter>().enabled = true;
            pickupTimer = pickupDuration;
            Destroy(other.gameObject);

        }
    }
}
