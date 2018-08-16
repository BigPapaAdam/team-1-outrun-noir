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
                GameLoader.GameInstance.SceneNumber += 1;
                levelTimer = 600.0f;
                GameLoader.GameInstance.Play();
            }
            else
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }            
        }

        //if (levelTimer <= levelDuration && Input.GetKeyDown(KeyCode.Space))
        //{
        //    SceneManager.LoadScene(GameLoader.GameInstance.SceneNumber, LoadSceneMode.Single);
        //}
    }
}
