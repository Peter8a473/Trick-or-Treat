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

        // If there are settings saved, load them
        if (PlayerPrefs.GetInt("CustomSaved") == 1) { LoadCustom(); }
        else { DefaultSettings(); SaveCustom(); PlayerPrefs.SetInt("CustomSaved", 1); }

        Debug.Log(costumes);
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
            PlayerPrefs.SetInt("CustomSaved", 0);
    }

    void DefaultSettings()
    {
        costumes = 4;
        people = 2;
        timer = 2;
    }

    public void LoadCustom()
    {
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
        int temp = (int) amount - costumes;
        if (temp > 0) { Costumes.Instance.IncrementSelection(Mathf.Abs(temp)); }
        else if (temp < 0) { Costumes.Instance.DecrementSelection(Mathf.Abs(temp)); }
        
        costumes = (int) amount;
        costumeText.text = "" + costumes;
    }

    public void ChangePeople(float amount)
    {
        int temp = (int) amount - people;
        if (temp > 0) { People.Instance.IncrementSelection(Mathf.Abs(temp)); }
        else if (temp < 0) { People.Instance.DecrementSelection(Mathf.Abs(temp)); }

        people = (int) amount;
        peopleText.text = "" + people;
    }

    public void ChangeTimer(float amount)
    {
        timer = (int) amount;
        timerText.text = "" + timer;
    }
}
