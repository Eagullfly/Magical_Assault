﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    //public string nextLevel = "Level02";
    //public int levelToUnlock = 2;

    /*public void Continue()
    {

    }*/
    
    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
