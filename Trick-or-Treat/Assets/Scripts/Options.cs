using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    const int BGM = 0;
    const int SFX = 1;

    [SerializeField] private AudioMixer audioMixer;
    
    [SerializeField] private Slider[] sliders = new Slider[2];
    [SerializeField] private float[] savedVal = new float[2];

    public void ChangeBGM(float amount)
    {
        audioMixer.SetFloat("BGM", amount);
        
    }

    public void ChangeSFX(float amount)
    {
        audioMixer.SetFloat("SFX", amount);
    }

    public void ToggleBGM(bool state)
    {
        sliders[BGM].interactable = !state;

        if (!state)
            audioMixer.SetFloat("BGM", sliders[BGM].value);
        else
            audioMixer.SetFloat("BGM", -80f);
    }

    public void ToggleSFX(bool state)
    {
        sliders[SFX].interactable = !state;
        
        if (!state)
            audioMixer.SetFloat("SFX", sliders[SFX].value);
        else
            audioMixer.SetFloat("SFX", -80f);
    }
}
