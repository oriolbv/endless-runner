using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);

        //if (UnityAdController.showAds)
        //{
            // Show an ad 
            UnityAdController.ShowAd();
        //}

    }
}
