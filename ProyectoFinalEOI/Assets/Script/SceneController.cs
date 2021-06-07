﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Battle");
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
