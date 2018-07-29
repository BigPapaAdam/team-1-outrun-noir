using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {


    float camRayLength = 1000f;
    //public Rigidbody playerRigidbody;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Turning();

    }

    void Turning()
    {
        int floorMask = LayerMask.GetMask("ground");

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(floorMask);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            transform.rotation = Quaternion.LookRotation(playerToMouse);
            //playerRigidbody.MoveRotation(newRotation);

        }
    }
}
