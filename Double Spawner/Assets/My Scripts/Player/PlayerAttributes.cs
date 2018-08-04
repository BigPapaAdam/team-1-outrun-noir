﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAttributes : MonoBehaviour {

    public float playerMaxHealth;
    public float playerHealth;
    public Image healthBarUI;

    public int activeAllies = 0;
    public Image[] allyIcon;

    public enum activeWeapon { Pistol, Tommy, Shotgun }
    public float pickupTimer;
    public float pickupDuration;
    public Text weaponTimerUI;

    //Damages
    public int bulletDamage = 1;
    public int spikeDamage = 1;

	// Use this for initialization
	void Start () {
        playerHealth = playerMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHealth <= 0)
        {
            GameLoader.GameInstance.Save();
            Destroy(gameObject);
        }

        if(activeAllies == 0)
        {
            healthBarUI.fillAmount = playerHealth / playerMaxHealth;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if(activeAllies <= 0)
            {
                playerHealth -= bulletDamage;
            }
            else
            {
                allyIcon[activeAllies].gameObject.SetActive(false);
                activeAllies -= 1;
            }
        }

        if(other.gameObject.tag == "AlliedMafia")
        {
            activeAllies += 1;
            allyIcon[activeAllies].gameObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("SpikeTrap"))
        {
            playerHealth -= spikeDamage;
            Destroy(other.gameObject);
        }
    }
}
