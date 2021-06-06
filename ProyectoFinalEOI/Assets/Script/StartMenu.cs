using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [Header("Main Music")]
    public GameObject soundMenu;

    [Header("Scene Manager")]
    public SceneController sceneManager;

    [Header("Space Sound")]
    public AudioSource spaceSound;
    
    StartMenu startMenu;

    [HideInInspector]
    public bool isMenuOpen;
    [HideInInspector]
    public string sceneName;

    private void Awake()
    {
        sceneName = "StartMenu";
        isMenuOpen = false;
    }

    private void Update()
    {
        IntroPath();
    }

    public void IntroPath()
    {
        if (Input.GetKeyDown("space"))
        {
            spaceSound.Play();
            sceneManager.BattleScene();
        }
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    public void OpenSoundMenu()
    {
        if (isMenuOpen == false)
        {
            soundMenu.SetActive(true);
            isMenuOpen = true;
        }
        else
        {
            soundMenu.SetActive(false);
            isMenuOpen = false;
        }

    }
}
