using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public AudioMixer Mixer1;
    public AudioMixer Mixer2;
    public AudioSource AudioSource1;
    public Slider slider1;
    public AudioSource AudioSource2;
    public Slider slider2;

    public void OnChangeSlider(float Value) 
    {
        Mixer1.SetFloat("Volume", Mathf.Log10(Value) * 20); // magic formula for audio, humans perceive audio on a logarithmic scale
        PlayerPrefs.SetFloat("Volume", Value);
        PlayerPrefs.Save();
    }
    public void OnChangeSlider2(float Value)
    {
        Mixer2.SetFloat("Volume2", Mathf.Log10(Value) * 20); // magic formula for audio, humans perceive audio on a logarithmic scale
        PlayerPrefs.SetFloat("Volume2", Value);
        PlayerPrefs.Save();
    }

    public void OnBeginDrag() 
    {
        AudioSource2.Play();
    }

    public void OnEndDrag() 
    {
        AudioSource2.Play();
    }


    // Start is called before the first frame update
    void Start()
    {
        float savedValue = PlayerPrefs.GetFloat("Volume", 0.3f);
        float savedValue2 = PlayerPrefs.GetFloat("Volume2", 0.3f);
        OnChangeSlider(savedValue); // remember volume, by default set to 0.3
        slider1.value = savedValue;
        OnChangeSlider(savedValue2); // remember volume, by default set to 0.3
        slider2.value = savedValue2;
    }

    
}
