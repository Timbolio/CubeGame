using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class maintainAudio : MonoBehaviour
{

    public AudioMixer Mixer;
    
    // Start is called before the first frame update
    void Start()
    {
        float savedValue = PlayerPrefs.GetFloat("Volume2", 0.3f);
        Mixer.SetFloat("Volume2", Mathf.Log10(savedValue) * 20); // magic formula for audio, humans perceive audio on a logarithmic scale
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
