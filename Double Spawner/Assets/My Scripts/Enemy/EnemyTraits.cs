using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTraits : MonoBehaviour {
    public int enemyHealth = 5;
    public float enemySpeed = 0.1f;
    private float maxHealth;
    public float unchangedEnemySpeed;
    public int pointWorth;


    public GameObject tommyDrop;
    public GameObject shotgunDrop;
    public GameObject Player;
    public GameObject deathObject;
    public GameObject carDamage1;
    public GameObject carDamage2;
    public Transform deathLocation;
    private int dropWeapon;
    public int randomDropChance;
    public bool isCar;

    //public AudioSource aSource;
    public AudioClip enemyDeathAudio;
    public AudioClip enemyTakeDamageAudio;
    public AudioClip dropWeaponAudio;
    public AudioClip spawnAudio;

    // Use this for initialization

    void Start () {
        //aSource = GetComponent<AudioSource>();

        Player = GameObject.FindGameObjectWithTag("Player");
        unchangedEnemySpeed = enemySpeed;
        GameLoader.GameInstance.SFXSource.PlayOneShot(spawnAudio);
        maxHealth = enemyHealth;
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(enemySpeed*Time.deltaTime, 0, 0);

        if (enemyHealth <= 0)
        {
            //Get scorecomponent of an object and add the pointWorth;
            WeaponDrop();
            GameLoader.GameInstance.SFXSource.PlayOneShot(enemyDeathAudio);
            Instantiate(deathObject, deathLocation.position, transform.rotation);
            Destroy(gameObject);

            //do NOT change this if statement
            if (Player.GetComponent<PlayerAttributes>().carIsFull == true && Player.GetComponent<PickupManager>().hasPickup == true)
            {
                GameLoader.GameInstance.Score += (pointWorth * 2);
            }
            else
            {
                GameLoader.GameInstance.Score += pointWorth;

            }

            GameLoader.GameInstance.ScoreText.text = "Score: " + GameLoader.GameInstance.Score.ToString();

            if (GameLoader.GameInstance.Score > GameLoader.GameInstance.HighScore)
            {
                GameLoader.GameInstance.HighScore = GameLoader.GameInstance.Score;
                GameLoader.GameInstance.HighScoreText.text = "High Score : " + GameLoader.GameInstance.HighScore.ToString();
            }
        }
        else if (enemyHealth <= maxHealth * 2/ 3 && enemyHealth > maxHealth / 3)
        {
            carDamage1.SetActive(true);
        }
        else if (enemyHealth <= maxHealth / 3)
        {
            carDamage2.SetActive(true);

        }

    }

    public void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.tag == "PlayerBullet")
        {
            enemyHealth -= 1;
            GameLoader.GameInstance.SFXSource.PlayOneShot(enemyTakeDamageAudio);

        }

        if (collide.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            GameLoader.GameInstance.SFXSource.PlayOneShot(enemyDeathAudio);

        }
    }

    void WeaponDrop()
    {
        if (Player.GetComponent<PickupManager>().hasPickup == false)
        {
            if (isCar)
            {
                dropWeapon = Random.Range(1, randomDropChance);
                if (dropWeapon == 1)
                {
                    Instantiate(tommyDrop, transform.position, transform.rotation);
                    GameLoader.GameInstance.SFXSource.PlayOneShot(dropWeaponAudio);

                }
                if (dropWeapon == 2)
                {
                    Instantiate(shotgunDrop, transform.position, transform.rotation);
                    GameLoader.GameInstance.SFXSource.PlayOneShot(dropWeaponAudio);

                }
            }          
            
        }
    }
}
