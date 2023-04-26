using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundOptions : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    public Slider MusicSlider;
    public Slider FXSlider;
    void Start()
    {
        SetVolume("MasterVolume", 1);
        SetVolume("MusicVolume", 1);
        SetVolume("FXVolume", 1);
        MusicSlider.value = 1;
        FXSlider.value = 1;
    }

    public void SetMusicVolume(){
        SetVolume("MusicVolume", MusicSlider.value);
    }

    public void SetFXVolume(){
        SetVolume("FXVolume", FXSlider.value);
    }

    public void SetVolume(string name, float value){
        float volume = Mathf.Log10(value)*20;

        if (value == 0)
            volume = -80;
        Debug.Log(audioMixer.SetFloat(name, volume));
    }
}
