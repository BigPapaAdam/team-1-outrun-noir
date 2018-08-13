using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndState : MonoBehaviour {

    public float levelTimer;
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
                Debug.Log(GameLoader.GameInstance.SceneNumber);
                GameLoader.GameInstance.SceneNumber += 1;
                Debug.Log(GameLoader.GameInstance.SceneNumber);
                levelTimer = levelDuration;
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
