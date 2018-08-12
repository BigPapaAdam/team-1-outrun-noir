using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDeleter : MonoBehaviour {

    private void OnTriggerEnter(Collider collide)
    {
        Destroy(collide.gameObject);
    }
}
