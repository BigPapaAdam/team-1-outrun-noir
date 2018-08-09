﻿using System.Collections;
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
    public GameObject backTopLaneSpawn;
    public GameObject backMidLaneSpawn;
    public GameObject backBotLaneSpawn;
    public GameObject topLaneDetector;
    public GameObject midLaneDetector;
    public GameObject botLaneDetector;

    //LANE SPAWN CHANCES
    public int minL1Chance = 0;
    public int maxL1Chance = 3;
    public int minL2Chance = 4;
    public int maxL2Chance = 6;
    public int minL3Chance = 7;
    public int maxL3Chance = 9;
    public int minP1Chance = 10;
    public int maxP1Chance = 12;
    public int minP2Chance = 13;
    public int maxP2Chance = 15;


    
    //ENEMY SPAWN CHANCES
    public int minCarChance = 0;
    public int maxCarChance = 3;
    public int minBikeChance = 4;
    public int maxBikeChance = 6;
    public int minObstacleChance = 7;
    public int maxObstacleChance = 9;


    //SIDELINE SPAWN CHANCE
    public int minPersonChance = 0;
    public int maxPersonChance = 1;
    public int minAllyChance = 2;
    public int maxAllyChance = 3;




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
            WhichLane = Random.Range(minL1Chance, maxP2Chance + 1);

            if (WhichLane >= minL1Chance && WhichLane <= maxL1Chance)
            {
                WhichLane = 0;
            }
            else if ((WhichLane >= minL2Chance && WhichLane <= maxL2Chance))
            {
                WhichLane = 1;
            }
            else if ((WhichLane >= minL3Chance && WhichLane <= maxL3Chance))
            {
                WhichLane = 2;
            }
            else if ((WhichLane >= minP1Chance && WhichLane <= maxP1Chance))
            {
                WhichLane = 3;
            }
            else if ((WhichLane >= minP2Chance && WhichLane <= maxP2Chance))
            {
                WhichLane = 4;
            }



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
        WhichEnemy = Random.Range(minCarChance, maxObstacleChance + 1);

        if (WhichEnemy >= minCarChance && WhichEnemy <= maxCarChance)
        {
            WhichEnemy = 0;
        }
        else if (WhichEnemy >= minBikeChance && WhichEnemy <= maxBikeChance)
        {
            WhichEnemy = 1;
        }
        else if (WhichEnemy >= minObstacleChance && WhichEnemy <= maxObstacleChance)
        {
            WhichEnemy = 2;
        }

        switch (WhichEnemy)
        {
            case 0:
                //Car                
                Instantiate(polCarPref, topLaneSpawn.transform.position, transform.rotation);
                break;
            case 1:
                //Bike
                if (topLaneDetector.GetComponent<LaneDetection>().motoSpawnable)
                {
                    Instantiate(polBikePref, backTopLaneSpawn.transform.position, transform.rotation);
                }
                break;
            case 2:
                //Spike
                Instantiate(spikeTrapObj, topLaneSpawn.transform.position, transform.rotation);
                break;
        }
    }

    void LaneTwo()
    {

        WhichEnemy = Random.Range(0, maxObstacleChance + 1);

        if (WhichEnemy >= minCarChance && WhichEnemy <= maxCarChance)
        {
            WhichEnemy = 0;
        }
        else if (WhichEnemy >= minBikeChance && WhichEnemy <= maxBikeChance)
        {
            WhichEnemy = 1;
        }
        else if (WhichEnemy >= minObstacleChance && WhichEnemy <= maxObstacleChance)
        {
            WhichEnemy = 2;
        }

        switch (WhichEnemy)
        {
            case 0:
                //Car                
                Instantiate(polCarPref, midLaneSpawn.transform.position, transform.rotation);
                break;
            case 1:
                //Bike
                if (midLaneDetector.GetComponent<LaneDetection>().motoSpawnable)
                {
                    Instantiate(polBikePref, backMidLaneSpawn.transform.position, transform.rotation);
                }
                break;
            case 2:
                //Spike
                Instantiate(spikeTrapObj, midLaneSpawn.transform.position, transform.rotation);
                break;
        }

    }

    void LaneThree()
    {
        WhichEnemy = Random.Range(0, maxObstacleChance + 1);

        if (WhichEnemy >= minCarChance && WhichEnemy <= maxCarChance)
        {
            WhichEnemy = 0;
        }
        else if (WhichEnemy >= minBikeChance && WhichEnemy <= maxBikeChance)
        {
            WhichEnemy = 1;
        }
        else if (WhichEnemy >= minObstacleChance && WhichEnemy <= maxObstacleChance)
        {
            WhichEnemy = 2;
        }

        switch (WhichEnemy)
        {
            case 0:
                //Car                
                Instantiate(polCarPref, botLaneSpawn.transform.position, transform.rotation);
                break;
            case 1:
                //Bike
                if (botLaneDetector.GetComponent<LaneDetection>().motoSpawnable)
                {
                    Instantiate(polBikePref, backBotLaneSpawn.transform.position, transform.rotation);
                }
                break;
            case 2:
                //Spike
                Instantiate(spikeTrapObj, botLaneSpawn.transform.position, transform.rotation);
                break;

        }
    }

    void PathTop()
    {

        SidelineRnd = Random.Range(minPersonChance, maxAllyChance + 1);

        if (SidelineRnd >= minPersonChance && SidelineRnd <= maxPersonChance)
        {
            SidelineRnd = 0;
        }
        else if (SidelineRnd >= minAllyChance && SidelineRnd <= maxAllyChance)
        {
            SidelineRnd = 1;
        }

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
        SidelineRnd = Random.Range(minPersonChance, maxAllyChance + 1);

        if (SidelineRnd >= minPersonChance && SidelineRnd <= maxPersonChance)
        {
            SidelineRnd = 0;
        }
        else if (SidelineRnd >= minAllyChance && SidelineRnd <= maxAllyChance)
        {
            SidelineRnd = 1;
        }


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

}
