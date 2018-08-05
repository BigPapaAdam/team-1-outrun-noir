using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            GameLoader.GameInstance.Save();

            if(GameLoader.GameInstance.SceneNumber < SceneManager.sceneCountInBuildSettings)
            {
                GameLoader.GameInstance.SceneNumber += 1;
                GameLoader.GameInstance.Play();
            }
            else
            {
                GameLoader.GameInstance.SceneNumber = 0;
                GameLoader.GameInstance.Play();
            }

        }
	}
}
