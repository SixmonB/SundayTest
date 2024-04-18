using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTarget : MonoBehaviour
{
    public int currentLevel = 1;
    public string sceneToLoad = "Level2";
    public string firstScene = "Level1";
    public bool isFinalLevel = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerBall")
        {
            int thisLevel = SceneManager.GetActiveScene().buildIndex;
            MyEventSystem.I.CompleteLevel(thisLevel);
            if (isFinalLevel)
            {
                SceneManager.LoadScene(firstScene);
            }
            else
            {
                string nextLevel = "Level" + (thisLevel+1).ToString();
                SceneManager.LoadScene(nextLevel);
            }
            //SceneManager.LoadScene(sceneToLoad);
        }
    }
}
