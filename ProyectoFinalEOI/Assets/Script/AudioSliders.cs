using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Slider))]
public class AudioSliders : MonoBehaviour {
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

        slider.onValueChanged.AddListener(delegate { UpdateValueOnChange(slider.value); });

    }
    public void UpdateValueOnChange(float value)
    {
        if (mixer != null)
        {
            mixer.SetFloat(volumeName, Mathf.Log(value) * 20f);

        }
        if (volumeLabel != null)
        {
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString() + "%";
        }

    }

    public void SaveChanges()
    {

    }

}
