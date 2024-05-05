using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Customize : MonoBehaviour
{
    [SerializeField] private int costumes;
    [SerializeField] private TextMeshProUGUI costumeText;

    [SerializeField] private int people;
    [SerializeField] private TextMeshProUGUI peopleText;

    [SerializeField] private int timer;
    [SerializeField] private TextMeshProUGUI timerText;

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
