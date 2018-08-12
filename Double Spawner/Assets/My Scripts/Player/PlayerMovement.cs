using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float parLaneTop = 5f;
	public float parLaneBot = -5f;
	public float laneOne = 2;
	public float  laneTwo = 0;
	public float laneThree = -2;

	public float laneDif = 2;
	public float currentLane = 0;

    public float playerSpeed = 0.1f;

    

    


	// Use this for initialization
	void Start ()
    {
        laneTwo = 0;
        laneOne = laneTwo + laneDif;        
        laneThree = laneTwo - laneDif;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(playerSpeed, 0, 0);

        if (Input.GetKeyDown(GameLoader.GameInstance.CharacterMoveUp))
        {
            if (currentLane == laneTwo)
            {
                transform.Translate(0, 0, laneDif);
                currentLane = laneOne;
			}
            else if (currentLane == laneThree)
            {
                transform.Translate(0, 0, laneDif);
                currentLane = laneTwo;
            }
		}

		if (Input.GetKeyDown(GameLoader.GameInstance.CharacterMoveDown))
		{
            if (currentLane == laneOne)
            {
                transform.Translate(0, 0, -laneDif);
                currentLane = laneTwo;
            }
            else if (currentLane == laneTwo)
            {
                transform.Translate(0, 0, -laneDif);
                currentLane = laneThree;
            }
        }
	}
}
