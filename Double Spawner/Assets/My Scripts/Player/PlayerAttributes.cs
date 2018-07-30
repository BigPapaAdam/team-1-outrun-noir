using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAttributes : MonoBehaviour {

    public float playerMaxHealth;
    public float playerHealth;
    public Image healthBarUI;

    public int activeAllies;
    public Image allyIcon1UI;
    public Image allyIcon2UI;
    public Image allyIcon3UI;

    public enum activeWeapon { Pistol, Tommy, Shotgun }
    public float pickupTimer;
    public float pickupDuration;
    public Text weaponTimerUI;

    public GameObject bulletSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        healthBarUI.fillAmount = playerHealth / playerMaxHealth;

        // New code added by Gordon-----------------------------------------------------
        // code to enable player to die for client meeting 2 (can be improved/changed later)
        if (playerHealth <= 0)
        {
            Destroy(gameObject);

        }
	}

    // New code added by Gordon
    // code to enable player to lose health for client meeting 2 (can be improved/changed later)
    public void OnCollisionEnter(Collision collide)
    {
        if(collide.gameObject.tag == "Bullet")
        {
            playerHealth -= 1;
        }

        if (collide.gameObject.tag == "Enemy")
        {
            playerHealth -= 2;
            Destroy(collide.gameObject);
        }



    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TommyDrop"))
        {
            bulletSpawn.GetComponent<PistolShooter>().enabled = false;
            bulletSpawn.GetComponent<TommyShooter>().enabled = true;
            bulletSpawn.GetComponent<ShotgunShooter>().enabled = false;
            Destroy(other.gameObject);
        }
    }
    // End code added by Gordon-----------------------------------------------------------

}
