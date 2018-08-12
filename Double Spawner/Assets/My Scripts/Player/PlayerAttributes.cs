using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAttributes : MonoBehaviour {

    public float playerMaxHealth;
    public float playerHealth;
    public Image healthBarUI;

    public static int activeAllies = 0;
    public int globalAlliesInCar;
    public Image[] allyIcon;
    public GameObject shooterSeat1;
    public GameObject shooterSeat2;
    public GameObject shooterSeat3;
    public GameObject FullHouseIcon;


    public enum activeWeapon { Pistol, Tommy, Shotgun }
    public float pickupTimer;
    public float pickupDuration;
    public Text weaponTimerUI;

    //Damages
    public int bulletDamage = 1;
    public int spikeDamage = 1;
    public int triadBlockCollisionDamage = 1;
    public int enemyCrashDamage = 1;

    public bool carIsFull;

    //Audio
    public AudioSource aSource;
    public AudioClip playerDeathAudio;
    public AudioClip playerTakeDamageAudio;
    public AudioClip allyDeathAudio;
    public AudioClip spikeTrapAudio;
    public AudioClip crashAudio;
    public AudioClip pickupAllyAudio;

    // Use this for initialization
    void Start () {
        aSource = GetComponent<AudioSource>();

        for (int i = 0; i < activeAllies; i++)
        {
            allyIcon[i].gameObject.SetActive(true);
            transform.GetChild(i).gameObject.SetActive(true);
        }

        playerHealth = playerMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        globalAlliesInCar = activeAllies;


        if (playerHealth <= 0)
        {
            GameLoader.GameInstance.Save();
            Destroy(gameObject);
            aSource.PlayOneShot(playerDeathAudio);

        }

        if (activeAllies == 0)
        {
            healthBarUI.fillAmount = playerHealth / playerMaxHealth;
        }

        switch (activeAllies)
        {
            case 0:
                shooterSeat1.gameObject.SetActive(false);
                shooterSeat2.gameObject.SetActive(false);
                shooterSeat3.gameObject.SetActive(false);
                break;
            case 1:
                shooterSeat1.gameObject.SetActive(true);
                shooterSeat2.gameObject.SetActive(false);
                shooterSeat3.gameObject.SetActive(false);
                break;
            case 2:
                shooterSeat1.gameObject.SetActive(true);
                shooterSeat2.gameObject.SetActive(true);
                shooterSeat3.gameObject.SetActive(false);
                break;
            case 3:
                shooterSeat1.gameObject.SetActive(true);
                shooterSeat2.gameObject.SetActive(true);
                shooterSeat3.gameObject.SetActive(true);
                break;

        }

        if(carIsFull == true && GetComponent<PickupManager>().hasPickup == true)
        {
            FullHouseIcon.SetActive(true);
        }
        else
        {
            FullHouseIcon.SetActive(false);
        }

        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (activeAllies <= 0)
            {
                playerHealth -= bulletDamage;
                aSource.PlayOneShot(playerTakeDamageAudio);

            }
            else
            {
                if (activeAllies > 0)
                {
                    activeAllies -= 1;
                    allyIcon[activeAllies].gameObject.SetActive(false);
                    aSource.PlayOneShot(allyDeathAudio);

                    carIsFull = false;
                }
            }
        }

        if (other.gameObject.tag == "Enemy")
        {
            if (activeAllies <= 0)
            {
                playerHealth -= enemyCrashDamage;
                aSource.PlayOneShot(crashAudio);

            }
            else
            {
                if (activeAllies > 0)
                {
                    activeAllies -= 1;
                    allyIcon[activeAllies].gameObject.SetActive(false);
                    aSource.PlayOneShot(crashAudio);

                    carIsFull = false;
                }
            }
        }

        if (other.gameObject.tag == "TriadBlock")
        {
            if (activeAllies <= 0)
            {
                playerHealth -= triadBlockCollisionDamage;
                aSource.PlayOneShot(crashAudio);

            }
            else
            {
                if (activeAllies > 0)
                {
                    activeAllies -= 1;
                    allyIcon[activeAllies].gameObject.SetActive(false);
                    aSource.PlayOneShot(crashAudio);

                    carIsFull = false;
                }
            }
        }

        if (other.gameObject.tag == "SpikeTrap")
        {
            if (activeAllies <= 0)
            {
                playerHealth -= spikeDamage;
                aSource.PlayOneShot(spikeTrapAudio);

            }
            else
            {
                if (activeAllies > 0)
                {
                    activeAllies -= 1;
                    allyIcon[activeAllies].gameObject.SetActive(false);
                    aSource.PlayOneShot(spikeTrapAudio);

                    carIsFull = false;
                }
            }
        }

        //if (other.gameObject.tag == "AlliedMafia")
        //{
        //    activeAllies += 1;
        //    allyIcon[activeAllies].gameObject.SetActive(true);
        //}


    }

    private void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "AlliedMafia")
        {
            if (activeAllies < 3)
            {
                allyIcon[activeAllies].gameObject.SetActive(true);
                activeAllies += 1;
                aSource.PlayOneShot(pickupAllyAudio);

            }

            if (activeAllies == 3)
            {
                carIsFull = true;
            }

            

            Destroy(collide.gameObject);
        }

        if (collide.gameObject.tag == "SpikeTrap")
        {
            print("spike");

            if (activeAllies <= 0)
            {
                playerHealth -= spikeDamage;
            }
            else if (activeAllies > 0)
            {
                activeAllies -= 1;
                allyIcon[activeAllies].gameObject.SetActive(false);
            }

            Destroy(collide.gameObject);
        }

        if (collide.gameObject.tag == "TriadBlock")
        {
            print("triadBlock");

            if (activeAllies <= 0)
            {
                playerHealth -= triadBlockCollisionDamage;
            }
            else if (activeAllies > 0)
            {
                activeAllies -= 1;
                allyIcon[activeAllies].gameObject.SetActive(false);
            }

            Destroy(collide.gameObject);
        }
    }
}
