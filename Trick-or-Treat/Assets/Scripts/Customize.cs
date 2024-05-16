using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Customize : MonoBehaviour
{
    public static Customize Instance;

    public static int costumes;
    [SerializeField] private Slider costumeSlider;
    [SerializeField] private TextMeshProUGUI costumeText;

    public static int people;
    [SerializeField] private Slider peopleSlider;
    [SerializeField] private TextMeshProUGUI peopleText;

    public static int timer;
    [SerializeField] private Slider timerSlider;
    [SerializeField] private TextMeshProUGUI timerText;

    void Awake()
    {
        Instance = this;

        if (PlayerPrefs.GetInt("CustomSaved") == 1) { LoadCustom(); }
        else { SaveCustom(); PlayerPrefs.SetInt("CustomSaved", 1); }
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
            PlayerPrefs.SetInt("CustomSaved", 0);
    }

    public void LoadCustom()
    {
        Debug.Log("Load");
        // Retrieve Data //
        costumes = PlayerPrefs.GetInt("costumes");
        people = PlayerPrefs.GetInt("people");
        timer = PlayerPrefs.GetInt("timer");

        // Load Data //
        ChangeCostumes(costumes);
        ChangePeople(people);
        ChangeTimer(timer);

        // Update UI //
        costumeSlider.value = costumes;
        peopleSlider.value = people;
        timerSlider.value = timer;
    }

    public void SaveCustom()
    {
        PlayerPrefs.SetInt("costumes", costumes);
        PlayerPrefs.SetInt("people", people);
        PlayerPrefs.SetInt("timer", timer);
    }

    public void ChangeCostumes(float amount)
    {
        costumes = (int) amount;
        costumeText.text = "" + costumes;
    }

    public void ChangePeople(float amount)
    {
        people = (int) amount;
        peopleText.text = "" + people;
    }

    public void ChangeTimer(float amount)
    {
        timer = (int) amount;
        timerText.text = "" + timer;
    }
}
