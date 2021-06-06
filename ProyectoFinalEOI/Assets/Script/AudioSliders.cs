using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Slider))]
public class AudioSliders : MonoBehaviour
{
     Slider slider
    {
        get { return GetComponent<Slider>(); }
    }

    [SerializeField]
    private AudioMixer mixer;

    [SerializeField]
    private string volumeName;
    [SerializeField]
    private TextMeshProUGUI volumeLabel;
     

    //public GameObject MenuAudio;
    private void Start()
    {
        UpdateValueOnChange(slider.value);

        slider.onValueChanged.AddListener(delegate
        {
            UpdateValueOnChange(slider.value);
        });

        //slider.value = PlayerPrefs.GetFloat(volumeName, 1f);
        // Set it at the start        <<<<
        //mixer.SetFloat(volumeName, Mathf.Log10(slider.value) * 20);
    }
    public void UpdateValueOnChange(float value)
    {
        if (mixer != null)
        {
            mixer.SetFloat(volumeName, Mathf.Log(value) * 20f);
             
        }
        if(volumeLabel !=null)
        {
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString() + "%";
        }

        //PlayerPrefs.SetFloat(volumeName, value);

        //mixer.SetFloat(volumeName, Mathf.Log10(value) * 20);
    }

    public void SaveChanges()
    { 
    
    }
     
}
