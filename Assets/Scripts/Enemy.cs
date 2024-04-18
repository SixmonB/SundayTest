using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int currentLevel = 1;
    public string sceneToLoad = "Level1";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerBall")
        {
            
            //SceneManager.LoadScene(sceneToLoad);
            int intThisLevel = SceneManager.GetActiveScene().buildIndex;
            string strThisLevel = "Level" + intThisLevel.ToString();
            SceneManager.LoadScene(strThisLevel);

            MyEventSystem.I.FailLevel(intThisLevel);
        }
    }
}
