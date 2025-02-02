﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public UiManager uiManager;

    public void BattleScene()
    {
        SceneManager.LoadScene("Battle");
    }

    public void Replay()
    {
        uiManager.RestartTime();
        SceneManager.LoadScene("StartMenu");
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
