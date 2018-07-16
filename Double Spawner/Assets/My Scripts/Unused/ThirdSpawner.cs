using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdSpawner : MonoBehaviour
{
    public GameObject PrimeSpawner;

    public void Spawn()
    {
        int Colour = Random.Range(0, 3);

        switch (Colour)
        {
            case 0:
                PrimeSpawner.GetComponent<Text>().color = Color.yellow;
                break;
            case 1:
                PrimeSpawner.GetComponent<Text>().color = Color.blue;
                break;
            case 2:
                PrimeSpawner.GetComponent<Text>().color = Color.red;
                break;
        }
    }
}
