using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconDisabler : MonoBehaviour {

    private float iconTimer;
    public float iconDuration;
	// Use this for initialization
	void Start () {
        iconTimer = iconDuration;
	}
	
	// Update is called once per frame
	void Update () {
        iconTimer -= Time.deltaTime;
        if (iconTimer <= 0)
        {
            Destroy(gameObject);
        }
	}
}
