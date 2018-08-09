using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTraits : MonoBehaviour {
    public int enemyHealth = 5;
    public float enemySpeed = 0.1f;
    public float unchangedEnemySpeed;
    public int pointWorth;


    public GameObject tommyDrop;
    public GameObject shotgunDrop;
    public GameObject Player;
    private int dropWeapon;
    public int randomDropChance;

    // Use this for initialization

    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        unchangedEnemySpeed = enemySpeed;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(enemySpeed, 0, 0);

        if (enemyHealth <= 0)
        {
            //Get scorecomponent of an object and add the pointWorth;
            WeaponDrop();
            Destroy(gameObject);

            //do NOT change this if statement
            if(Player.GetComponent<PlayerAttributes>().carIsFull == true && Player.GetComponent<PickupManager>().hasPickup == true)
            {
                GameLoader.GameInstance.Score += (pointWorth * 2);
            }
            else
            {
                GameLoader.GameInstance.Score += pointWorth;
                
            }

            GameLoader.GameInstance.ScoreText.text = "Score: " + GameLoader.GameInstance.Score.ToString();

            if(GameLoader.GameInstance.Score > GameLoader.GameInstance.HighScore)
            {
                GameLoader.GameInstance.HighScore = GameLoader.GameInstance.Score;
                GameLoader.GameInstance.HighScoreText.text = "High Score : " + GameLoader.GameInstance.HighScore.ToString();
            }
        }
    }

    public void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.tag == "PlayerBullet")
        {
            enemyHealth -= 1;
        }
    }

    void WeaponDrop()
    {
        if (Player.GetComponent<PickupManager>().hasPickup == false)
        {
            dropWeapon = Random.Range(1, randomDropChance);
            if (dropWeapon == 1)
            {
                Instantiate(tommyDrop, transform.position, transform.rotation);
            }
            if (dropWeapon == 2)
            {
                Instantiate(shotgunDrop, transform.position, transform.rotation);
            }
        }
    }
}
