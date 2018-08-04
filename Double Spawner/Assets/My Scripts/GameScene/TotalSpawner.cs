using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalSpawner : MonoBehaviour {
    //CHARACTERS
    public GameObject polCarPref;
    public GameObject polBikePref;
    public GameObject polPersonPref;
    public GameObject playerObject;
    public GameObject spikeTrapObj;

    //EGO SPAWN LOCATIONS
    public GameObject topLaneSpawn;
    public GameObject midLaneSpawn;
    public GameObject botLaneSpawn;
    public GameObject topPathSpawn;
    public GameObject botPathSpawn;


    public float SpawnTimer = 2.0f;
    public float TempTimer = 0.0f;

    public int WhichLane;
    public int WhichEnemy;

    // Use this for initialization
    void Start () {
        SpawnTimer = 2.0f;
        TempTimer = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        TempTimer += Time.deltaTime;

        if (TempTimer >= SpawnTimer)
        {
            //Lane Selection
            WhichLane = Random.Range(0, 5);
            switch (WhichLane)
            {
                case 0:
                    LaneOne();
                    break;
                case 1:
                    LaneTwo();
                    break;
                case 2:
                    LaneThree();
                    break;
                case 3:
                    PathTop();
                    break;
                case 4:
                    PathBot();
                    break;
            }
            TempTimer = 0.0f;
        }

    }

    void LaneOne()
    {
        WhichEnemy = Random.Range(0, 3);
        switch (WhichEnemy)
        {
            case 0:
                //Car                
                Instantiate(polCarPref, topLaneSpawn.transform.position, transform.rotation);
                break;
            case 1:
                //Bike
                Instantiate(polBikePref, topLaneSpawn.transform.position, transform.rotation);
                break;
            case 2:
                //Bike
                Instantiate(spikeTrapObj, topLaneSpawn.transform.position, transform.rotation);
                break;
        }
    }

    void LaneTwo()
    {

        WhichEnemy = Random.Range(0, 3);
        switch (WhichEnemy)
        {
            case 0:
                //Car                
                Instantiate(polCarPref, midLaneSpawn.transform.position, transform.rotation);
                break;
            case 1:
                //Bike
                Instantiate(polBikePref, midLaneSpawn.transform.position, transform.rotation);
                break;
            case 2:
                //Bike
                Instantiate(spikeTrapObj, topLaneSpawn.transform.position, transform.rotation);
                break;
        }

    }

    void LaneThree()
    {
        WhichEnemy = Random.Range(0, 3);
        switch (WhichEnemy)
        {
            case 0:
                //Car                
                Instantiate(polCarPref, botLaneSpawn.transform.position, transform.rotation);
                break;
            case 1:
                //Bike
                Instantiate(polBikePref, botLaneSpawn.transform.position, transform.rotation);
                break;
            case 2:
                //Bike
                Instantiate(spikeTrapObj, topLaneSpawn.transform.position, transform.rotation);
                break;
        }
    }

    void PathTop()
    {
        Instantiate(polPersonPref, topPathSpawn.transform.position, transform.rotation);
    }

    void PathBot()
    {
        Instantiate(polPersonPref, botPathSpawn.transform.position, transform.rotation);
    }
}
