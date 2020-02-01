using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{

    Slider volSlider;
    Text Voltext;
    private void Awake()
    {
        volSlider = GetComponentInChildren < Slider >();
        Voltext = GetComponentInChildren<Text>();
        Voltext.text = "Volume: " + (AudioListener.volume * 100).ToString("F0") + "%";
        volSlider.value = AudioListener.volume;
    }

    public void ChangeVolume(float currentVol)
    {
        AudioListener.volume = currentVol;
        Voltext.text = "Volume: " + (currentVol * 100).ToString("F0")+"%";
    }
}
