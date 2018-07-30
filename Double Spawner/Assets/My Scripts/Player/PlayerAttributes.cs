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
    public int bulletDamage = 1;

	// Use this for initialization
	void Start () {
        playerHealth = playerMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
        healthBarUI.fillAmount = playerHealth / playerMaxHealth;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            playerHealth -= 1;
        }
    }
}
