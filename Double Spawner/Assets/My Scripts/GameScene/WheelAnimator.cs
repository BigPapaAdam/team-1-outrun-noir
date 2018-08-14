using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAnimator : MonoBehaviour {

    public GameObject wheel1;
    public GameObject wheel2;

    public float animTimer = 0;
    public float animLength = 0.25f;

    private bool wheel1Active = true;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        animTimer -= Time.deltaTime;

        if (animTimer <= 0)
        {
            wheel1Active = !wheel1Active;
            animTimer = animLength;
        }

        if (wheel1Active == true)
        {
            wheel1.gameObject.SetActive(true);
            wheel2.gameObject.SetActive(false);
        }
        else
        {
            wheel2.gameObject.SetActive(true);
            wheel1.gameObject.SetActive(false);
        }
	}
}
