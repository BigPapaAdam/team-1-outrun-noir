using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalSpawner : MonoBehaviour {
    //CHARACTERS
    public GameObject polCarPref;
    public GameObject polBikePref;
    public GameObject polPersonPrefBot;
    public GameObject polPersonPrefTop;
    public GameObject playerObject;
    public GameObject spikeTrapObj;
    public GameObject alliedMafiaObj;
    //public GameObject triadBlockObj;

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
    public int SidelineRnd;

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
                //Spike
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
                //Spike
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
                //Spike
                Instantiate(spikeTrapObj, topLaneSpawn.transform.position, transform.rotation);
                break;

        }
    }

    void PathTop()
    {
        //Instantiate(polPersonPrefTop, topPathSpawn.transform.position, topPathSpawn.transform.rotation);
        //Instantiate(alliedMafiaObj, topPathSpawn.transform.position, transform.rotation);
        SidelineRnd = Random.Range(0, 2);
        switch (SidelineRnd)
        {
            case 0:
                //Car                
                Instantiate(polPersonPrefTop, topPathSpawn.transform.position, topPathSpawn.transform.rotation);
                break;
            case 1:
                //Bike
                Instantiate(alliedMafiaObj, topPathSpawn.transform.position, transform.rotation);
                break;
        }
    }

       void PathBot()
    {
        //Instantiate(polPersonPrefBot, botPathSpawn.transform.position, botPathSpawn.transform.rotation);
        //Instantiate(alliedMafiaObj, botPathSpawn.transform.position, transform.rotation);

        SidelineRnd = Random.Range(0, 2);
        switch (SidelineRnd)
        {
            case 0:
                //Car                
                Instantiate(polPersonPrefBot, botPathSpawn.transform.position, botPathSpawn.transform.rotation);
                break;
            case 1:
                //Bike
                Instantiate(alliedMafiaObj, botPathSpawn.transform.position, transform.rotation);
                break;
        }
    }

    //USE OnTriggerStay to detect what is in the lane
}
