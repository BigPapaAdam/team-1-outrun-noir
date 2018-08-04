using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidelinerRotator : MonoBehaviour {

    private int rndRotate;

    public int straightAngle = 0;
    public int rotationOffStraight = 30;
	// Use this for initialization
	void Start () {
        rndRotate = Random.Range(0, 3);

        switch (rndRotate)
        {
            case 0:
                transform.eulerAngles = new Vector3(0, -rotationOffStraight, 0);
                break;
            case 1:
                transform.eulerAngles = new Vector3(0, straightAngle, 0);
                break;
            case 2:
                transform.eulerAngles = new Vector3(0, rotationOffStraight, 0);

                break;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
