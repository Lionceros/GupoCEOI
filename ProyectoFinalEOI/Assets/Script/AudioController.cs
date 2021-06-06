using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour {

    private bool isMuted;
    public Image mutedImageButton;

    void Start()
    {
        isMuted = PlayerPrefs.GetInt("Muted") == 1;
        AudioListener.pause = isMuted;
    }

    public void SoundMuted()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);


        // Me falta añadir codigo para cambiar la imagen del fondo del botón
        
    }
}
