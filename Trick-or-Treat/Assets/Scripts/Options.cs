using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public static Options Instance;

    const int BGM = 0;
    const int SFX = 1;

    [SerializeField] private AudioMixer audioMixer;
    
    [SerializeField] private Slider[] sliders = new Slider[2];
    [SerializeField] private Toggle[] toggles = new Toggle[2];
    private float[] values = {-10f, -10f};
    private int[] states = {1, 1};

    void Awake()
    {
        Instance = this;

        if (PlayerPrefs.GetInt("OptionsSaved") == 1) { LoadOptions(); }
        else { SaveOptions(); PlayerPrefs.SetInt("OptionsSaved", 1); }
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
            PlayerPrefs.SetInt("OptionsSaved", 0);
    }

    public void LoadOptions()
    {
        // Retrieve Data //
        values[BGM] = PlayerPrefs.GetFloat("values[BGM]");
        states[BGM] = PlayerPrefs.GetInt("states[BGM]");

        values[SFX] = PlayerPrefs.GetFloat("values[SFX]");
        states[SFX] = PlayerPrefs.GetInt("states[SFX]");

        // Load Data //
        ChangeBGM(values[BGM]);
        if (states[BGM] == 0) { ToggleBGM(true); }

        ChangeSFX(values[SFX]);
        if (states[SFX] == 0) { ToggleSFX(true); }

        // Update UI //
        sliders[BGM].value = values[BGM];
        if (states[BGM] == 1) { toggles[BGM].isOn = false; }
        else { toggles[BGM].isOn = true; }

        sliders[SFX].value = values[SFX];
        if (states[SFX] == 1) { toggles[SFX].isOn = false; }
        else { toggles[SFX].isOn = true; }
    }

    public void SaveOptions()
    {
        PlayerPrefs.SetFloat("values[BGM]", values[BGM]);
        PlayerPrefs.SetInt("states[BGM]", states[BGM]);

        PlayerPrefs.SetFloat("values[SFX]", values[SFX]);
        PlayerPrefs.SetInt("states[SFX]", states[SFX]);
    }

    public void ChangeBGM(float amount)
    {
        values[BGM] = amount;
        audioMixer.SetFloat("BGM", values[BGM]);
    }

    public void ChangeSFX(float amount)
    {
        values[SFX] = amount;
        audioMixer.SetFloat("SFX", values[SFX]);
    }

    public void ToggleBGM(bool state)
    {
        sliders[BGM].interactable = !state;

        if (!state)
        {
            audioMixer.SetFloat("BGM", values[BGM]);
            states[BGM] = 1;
        }
        else
        {
            audioMixer.SetFloat("BGM", -80f);
            states[BGM] = 0;
        }
    }

    public void ToggleSFX(bool state)
    {
        sliders[SFX].interactable = !state;
        
        if (!state)
        {
            audioMixer.SetFloat("SFX", values[SFX]);
            states[SFX] = 1;
        }
        else
        {
            audioMixer.SetFloat("SFX", -80f);
            states[SFX] = 0;
        }
    }
}
