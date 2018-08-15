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
    public GameObject shooterSprite1;
    public GameObject shooterSprite2;
    public GameObject shooterSprite3;
    public GameObject FullHouseIcon;

    public GameObject carDamage1;
    public GameObject carDamage2;
    public GameObject ally1Death;
    public GameObject ally2Death;
    public GameObject ally3Death;

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

    public AudioClip playerDeathAudio;
    public AudioClip playerTakeDamageAudio;
    public AudioClip allyDeathAudio1;
    public AudioClip allyDeathAudio2;
    public AudioClip allyDeathAudio3;
    public AudioClip spikeTrapAudio;
    public AudioClip crashAudio;
    public AudioClip pickupAllyAudio;
    public AudioClip EngineSound;

    // Use this for initialization
    void Start () {
        GameLoader.GameInstance.EngineSource.clip = EngineSound;

        GameLoader.GameInstance.EngineSource.Play();

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

            GameLoader.GameInstance.SFXSource.PlayOneShot(playerDeathAudio);
            GameLoader.GameInstance.SFXSource.clip = GameLoader.GameInstance.SFX01;

        }
        else if (playerHealth == 2)
        {
            carDamage1.SetActive(true);
        }
        else if (playerHealth == 1)
        {
            carDamage2.SetActive(true);
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
                shooterSprite1.gameObject.SetActive(false);
                shooterSprite2.gameObject.SetActive(false);
                shooterSprite3.gameObject.SetActive(false);
                break;
            case 1:
                shooterSeat1.gameObject.SetActive(true);
                shooterSeat2.gameObject.SetActive(false);
                shooterSeat3.gameObject.SetActive(false);
                shooterSprite1.gameObject.SetActive(true);
                shooterSprite2.gameObject.SetActive(false);
                shooterSprite3.gameObject.SetActive(false);
                break;
            case 2:
                shooterSeat1.gameObject.SetActive(true);
                shooterSeat2.gameObject.SetActive(true);
                shooterSeat3.gameObject.SetActive(false);
                shooterSprite1.gameObject.SetActive(true);
                shooterSprite2.gameObject.SetActive(true);
                shooterSprite3.gameObject.SetActive(false);
                break;
            case 3:
                shooterSeat1.gameObject.SetActive(true);
                shooterSeat2.gameObject.SetActive(true);
                shooterSeat3.gameObject.SetActive(true);
                shooterSprite1.gameObject.SetActive(true);
                shooterSprite2.gameObject.SetActive(true);
                shooterSprite3.gameObject.SetActive(true);
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
                GameLoader.GameInstance.SFXSource.PlayOneShot(playerTakeDamageAudio);

            }
            else
            {
                if (activeAllies > 2)
                {
                    activeAllies -= 1;
                    allyIcon[activeAllies].gameObject.SetActive(false);
                    GameLoader.GameInstance.SFXSource.PlayOneShot(allyDeathAudio3);
                    Instantiate(ally3Death, transform.position, transform.rotation);
                    carIsFull = false;
                }
                else if (activeAllies > 1)
                {
                    activeAllies -= 1;
                    allyIcon[activeAllies].gameObject.SetActive(false);
                    GameLoader.GameInstance.SFXSource.PlayOneShot(allyDeathAudio2);
                    Instantiate(ally2Death, transform.position, transform.rotation);
                    carIsFull = false;
                }
                else if (activeAllies > 0)
                {
                    activeAllies -= 1;
                    allyIcon[activeAllies].gameObject.SetActive(false);
                    GameLoader.GameInstance.SFXSource.PlayOneShot(allyDeathAudio1);
                    Instantiate(ally1Death, transform.position, transform.rotation);
                    carIsFull = false;
                }
            }
        }

        //if (other.gameObject.tag == "Enemy")
        //{
        //    if (activeAllies <= 0)
        //    {
        //        playerHealth -= enemyCrashDamage;
        //        aSource.PlayOneShot(crashAudio);

        //    }
        //    else
        //    {
        //        if (activeAllies > 0)
        //        {
        //            activeAllies -= 1;
        //            allyIcon[activeAllies].gameObject.SetActive(false);
        //            aSource.PlayOneShot(crashAudio);

        //            carIsFull = false;
        //        }
        //    }
        //}

        if (other.gameObject.tag == "TriadBlock")
        {
            if (activeAllies <= 0)
            {
                playerHealth -= triadBlockCollisionDamage;
                GameLoader.GameInstance.SFXSource.PlayOneShot(crashAudio);

            }
            else
            {
                if (activeAllies > 0)
                {
                    activeAllies -= 1;
                    allyIcon[activeAllies].gameObject.SetActive(false);
                    GameLoader.GameInstance.SFXSource.PlayOneShot(crashAudio);

                    carIsFull = false;
                }
            }
        }

        if (other.gameObject.tag == "SpikeTrap")
        {
            if (activeAllies <= 0)
            {
                playerHealth -= spikeDamage;
                GameLoader.GameInstance.SFXSource.PlayOneShot(spikeTrapAudio);

            }
            else
            {
                if (activeAllies > 0)
                {
                    activeAllies -= 1;
                    allyIcon[activeAllies].gameObject.SetActive(false);
                    GameLoader.GameInstance.SFXSource.PlayOneShot(spikeTrapAudio);

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
                GameLoader.GameInstance.SFXSource.PlayOneShot(pickupAllyAudio);

            }

            if (activeAllies == 3)
            {
                carIsFull = true;
            }

            Debug.Log("picked up mafia");

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

        if (collide.gameObject.tag == "Enemy")
        {
            if (activeAllies <= 0)
            {
                playerHealth -= enemyCrashDamage;
                GameLoader.GameInstance.SFXSource.PlayOneShot(crashAudio);

            }
            else
            {
                if (activeAllies > 0)
                {
                    activeAllies -= 1;
                    allyIcon[activeAllies].gameObject.SetActive(false);
                    GameLoader.GameInstance.SFXSource.PlayOneShot(crashAudio);

                    carIsFull = false;
                }
            }

            Destroy(collide.gameObject);
        }
    }
}
