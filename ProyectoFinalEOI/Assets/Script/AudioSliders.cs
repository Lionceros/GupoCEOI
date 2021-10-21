using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Slider))]
public class AudioSliders : MonoBehaviour {
    public Slider slider
    {
        get { return GetComponent<Slider>(); }
    }

    [SerializeField]
    private AudioMixer mixer;

    public string volumeName;
    [SerializeField]
    private TextMeshProUGUI volumeLabel;

    
    //public GameObject MenuAudio;
    private void OnEnable()
    {


        LoadSound();
        

        slider.onValueChanged.AddListener(UpdateValueOnChange);

    }
    public void UpdateValueOnChange(float value)
    {
        PlayerPrefs.SetFloat(volumeName, value);

        if (mixer != null)
        {
            Debug.Log(value);
            mixer.SetFloat(volumeName, Mathf.Log(value) * 20f);

        }
        if (volumeLabel != null)
        {
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString() + "%";
        }
    }

    //public void SaveChanges()
    //{
    //    PlayerPrefs.Save();
    //}

    private void OnDisable()
    {
        slider.onValueChanged.RemoveListener(UpdateValueOnChange);
    }

    public void LoadSound()
    {
        if (PlayerPrefs.HasKey(volumeName))
        {

            slider.value = PlayerPrefs.GetFloat(volumeName);
            Debug.Log(volumeName + ": " + slider.value);
        }

        UpdateValueOnChange(slider.value);
    }

}
