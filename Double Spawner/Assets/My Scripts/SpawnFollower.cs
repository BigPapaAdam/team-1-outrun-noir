using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFollower : MonoBehaviour {

    public GameObject playerObj;

    //temp
    public float spawnerSpeed = 0.1f;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //temp
        transform.Translate(spawnerSpeed, 0, 0);
        
        //Could change this to every time W or S is pressed. Avoids frame issue
        //THIS IS WHAT SHOULD BE USED
        //transform.position = new Vector3(playerObj.transform.position.x, 0, 0);
    }
}
