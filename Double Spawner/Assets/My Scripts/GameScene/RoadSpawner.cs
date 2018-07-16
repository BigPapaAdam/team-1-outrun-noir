using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour {

    public GameObject roadSquare1;
    public GameObject roadSquare2;
    public GameObject roadSquare3;

    public int roadSquareWidth = 10;
    public GameObject roadLocationSpawn;

    private int WhichRoadType;
    private int roadRepeat;
    private int roadTotal = 0;

    public int roadMax = 10;
    public int roadSectionMin = 3;
    public int roadSectionMax = 5;

    


    // Use this for initialization
    void Start () {
        while (roadTotal < roadMax)
        {
            WhichRoadType = Random.Range(0, 3);
            switch (WhichRoadType)
            {
                case 0:
                    //Road1                
                    RoadOne();
                    break;
                case 1:
                    //Road2
                    RoadTwo();
                    break;
                case 2:
                    //Road2
                    RoadThree();
                    break;
            }
        }
    }

    void RoadOne()
    {
        roadRepeat = Random.Range(roadSectionMin, roadSectionMax);
        for (int i = 1; i < roadRepeat; i += 1)
        {
            Instantiate(roadSquare1, roadLocationSpawn.transform.position, transform.rotation);
            roadLocationSpawn.transform.Translate(roadSquareWidth, 0, 0);
            roadTotal += 1;
        }

        
    }

    void RoadTwo()
    {
        roadRepeat = Random.Range(roadSectionMin, roadSectionMax);
        for (int i = 1; i < roadRepeat; i += 1)
        {
            Instantiate(roadSquare2, roadLocationSpawn.transform.position, transform.rotation);
            roadLocationSpawn.transform.Translate(roadSquareWidth, 0, 0);
            roadTotal += 1;
        }
    }

    void RoadThree()
    {
        roadRepeat = Random.Range(roadSectionMin, roadSectionMax);
        for (int i = 1; i < roadRepeat; i += 1)
        {
            Instantiate(roadSquare3, roadLocationSpawn.transform.position, transform.rotation);
            roadLocationSpawn.transform.Translate(roadSquareWidth, 0, 0);
            roadTotal += 1;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
