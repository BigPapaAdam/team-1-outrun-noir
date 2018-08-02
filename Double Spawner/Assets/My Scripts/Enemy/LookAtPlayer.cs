using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LookAtPlayer : MonoBehaviour {

    public GameObject playerObj;

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update () {
        if(playerObj == null)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        else
        {
            transform.LookAt(playerObj.transform.position);
        }
    }
}
