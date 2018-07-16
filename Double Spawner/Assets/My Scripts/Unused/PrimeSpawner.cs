using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimeSpawner : MonoBehaviour
{
    public float SpawnTimer = 3.0f;
    public float TempTimer = 0.0f;
    public int WhichSpawner;
    public GameObject FirstSpawner;
    public GameObject SecondSpawner;
    public GameObject ThirdSpawner;

    // Use this for initialization
    void Start ()
    {
        SpawnTimer = 3.0f;
        TempTimer = 0.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        TempTimer += Time.deltaTime;

        if(TempTimer >= SpawnTimer)
        {
            WhichSpawner = Random.Range(0, 3);
            switch (WhichSpawner)
            {
                case 0:
                    GetComponent<Text>().text = "First Spawner";
                    FirstSpawner.GetComponent<FirstSpawner>().Spawn();
                    break;
                case 1:
                    GetComponent<Text>().text = "Second Spawner";
                    SecondSpawner.GetComponent<SecondSpawner>().Spawn();
                    break;
                case 2:
                    GetComponent<Text>().text = "Third Spawner";
                    ThirdSpawner.GetComponent<ThirdSpawner>().Spawn();
                    break;
            }
            TempTimer = 0.0f;
        }
	}
}
