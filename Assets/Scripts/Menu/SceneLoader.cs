﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	
	public void SetGameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
    }

    public void SetMainMenu()
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void SetLevel1()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("Level 1");
    }

    public void SetCharSelect()
    {
        SceneManager.LoadScene("CharSelect");
        Debug.Log("Character Select");
    }

    public void SetExit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void SetRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Retry");
    }
}
