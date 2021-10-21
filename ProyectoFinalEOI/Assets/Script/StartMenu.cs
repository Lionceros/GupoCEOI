using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class StartMenu : MonoBehaviour
{
    [Header("Main Music")]
    public GameObject soundMenu;

    [Header("Scene Manager")]
    public SceneController sceneManager;

    [Header("Space Sound")]
    public AudioSource spaceSound;
    
    StartMenu startMenu;

    [Header("Credits")]
    public GameObject creditMenu;
    public TextMeshProUGUI creditText;

    [HideInInspector]
    public bool isMenuOpen;
    [HideInInspector]
    public bool isCreditMenuOpen;
    [HideInInspector]
    public string sceneName;

    public AudioMixer mixer;

    private void Awake()
    {
        sceneName = "StartMenu";
        isMenuOpen = false;
        isCreditMenuOpen = false;
        creditText.text = "Credits";




    }

    private void Start()
    {
        AudioSliders[] sliders = soundMenu.GetComponentsInChildren<AudioSliders>();

        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].LoadSound();
        }
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
            soundMenu.SetActive(false);
            creditMenu.SetActive(false);
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
            PlayerPrefs.Save();
        }
    }

    public void escapeButton()
    {
        Application.Quit();
    }

    public void Credits()
    {
        if (isCreditMenuOpen == false)
        {
            creditMenu.SetActive(true);
            creditText.text = "Back";
            isCreditMenuOpen = true;
        }
        else
        {
            creditMenu.SetActive(false);
            creditText.text = "Credits";
            isCreditMenuOpen = false;
        }
    }

}
