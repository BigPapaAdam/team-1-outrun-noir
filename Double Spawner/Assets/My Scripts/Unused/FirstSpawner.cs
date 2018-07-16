using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstSpawner : MonoBehaviour
{
    public GameObject PrimeSpawner;
    public Vector3 topEnemySpawn = new Vector3 (2,0,0);
    public GameObject enemyCarPrefab;
    public GameObject enemyBikePrefab;
    public GameObject enemyPersonPrefab;


    void Start()
    {
        
    }


    public void Spawn()
    {
        int Colour = Random.Range(0, 3);

        switch (Colour)
        {
            case 0:
                PrimeSpawner.GetComponent<Text>().color = Color.red;
                break;
            case 1:
                PrimeSpawner.GetComponent<Text>().color = Color.yellow;
                break;
            case 2:
                PrimeSpawner.GetComponent<Text>().color = Color.blue;
                break;
        }
    }
}
