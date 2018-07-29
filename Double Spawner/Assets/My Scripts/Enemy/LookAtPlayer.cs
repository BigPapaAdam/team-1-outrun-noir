using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

    public GameObject playerObj;

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update () {

        //changed code by Gordon
        //transform.LookAt(playerObj.GetComponent<ObjectSceneManager>().playerObj.transform);
        transform.LookAt(playerObj.transform);
    }
}
