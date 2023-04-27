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

        if(PlayerPrefs.GetInt("set first time volume") != 1){
            PlayerPrefs.SetInt("set first time volume",1);
            MusicSlider.value = 1.0f;
            FXSlider.value = 1.0f;
        }else{
            MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            FXSlider.value = PlayerPrefs.GetFloat("FXVolume");
        }
        
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
        audioMixer.SetFloat(name, volume);
        PlayerPrefs.SetFloat(name, value);
    }
}
