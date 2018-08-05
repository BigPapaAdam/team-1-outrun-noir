using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : MonoBehaviour {

    private float levelTimer;
    public float levelDuration;

	// Use this for initialization
	void Start () {
        levelTimer = levelDuration;
	}
	
	// Update is called once per frame
	void Update () {
        levelTimer -= Time.deltaTime;
        if (levelTimer <= 0)
        {
            //Scene Change
        }
	}
}
