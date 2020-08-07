﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MainMenu
{
    public static bool paused; 
 
    [Tooltip("Reference to the pause menu object to turn on/off")] 
    public GameObject pauseMenu; 
 
    /// <summary> 
    /// Reloads our current level, effectively "restarting" the game 
    /// </summary> 
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
 
    /// <summary> 
    /// Will turn our pause menu on or off 
    /// </summary> 
    /// <param name="isPaused"></param> 
    public void SetPauseMenu(bool isPaused) 
    { 
        paused = isPaused; 
 
        // If the game is paused, timeScale is 0, otherwise 1 
        Time.timeScale = (paused) ? 0 : 1; 
        pauseMenu.SetActive(paused); 
    } 
 
    void Start() 
    { 
        paused = false; 
        SetPauseMenu(false);
    } 

    void Update() {
        if (Input.GetKeyUp(KeyCode.P))
        {
            SetPauseMenu(true);
        }
    }
}
