using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class People : MonoBehaviour
{
    public static People Instance;

    public static Sprite[] personIMG = new Sprite[16];
    public static bool[] selection = new bool[16];

    public int selectionCount;
    public TextMeshProUGUI selectionText;

    public Toggle[] buttons = new Toggle[16];

    void Start()
    {
        Instance = this;

        for (int i = 0; i < 16; i++)
        {
            selection[i] = false; // Sets all people to false
            Image[] temp = buttons[i].gameObject.GetComponentsInChildren<Image>(); // Retrieves the sprites for a static variable
            personIMG[i] = temp[1].sprite;
        }

        // If there are people saved, load them
        if (PlayerPrefs.GetInt("PeopleSaved") == 1) { LoadPeople(); }
        else { Default(); SavePeople(); PlayerPrefs.SetInt("PeopleSaved", 1); }
    }
    
    void Update()
    {
        if (Input.GetKeyDown("r"))
            PlayerPrefs.SetInt("PeopleSaved", 0);
    }

    // Initializes the people to a default state
    void Default()
    {
        selectionCount = 2;
        Debug.Log(selectionCount);
        EnableButtons(true);
        for (int i = 0; i < 2; i++)
        {
            buttons[i].isOn = true;
        }
        Debug.Log(selectionCount);
        selectionText.text = selectionCount.ToString();
        EnableButtons(false);
    }

    public void LoadPeople()
    {
        // Retrieve Data //
        selectionCount = Customize.people;
        for (int i = 0; i < 16; i++)
        {
            if (PlayerPrefs.GetInt("person " + i.ToString()) == 1)
            {
                buttons[i].isOn = true;
            }
        }

        selectionText.text = selectionCount.ToString();
        EnableButtons(false);
    }

    public void SavePeople()
    {
        int h = 0;
        Debug.Log(selectionCount);
        while (selectionCount > 0)
        {
            Debug.Log(selectionCount);
            if (!selection[h])
            {
                buttons[h].isOn = true;
            }
            h++;
        }

        for (int i = 0; i < 16; i++)
        {
            if (selection[i]) { PlayerPrefs.SetInt("person " + i.ToString(), 1); }
            else { PlayerPrefs.SetInt("person " + i.ToString(), 0); }
        }
    }

    // Adjusts the selection if the person amount increases
    public void IncrementSelection(int amount)
    {
        selectionCount += amount;
        EnableButtons(true);
        int i = 0;
        while (amount > 0)
        {
            if (!selection[i])
            {
                buttons[i].isOn = true;
                amount--;
            }

            if (++i > 15) { break; }
        }
    }

    // Adjusts the selection if the person amount decreases
    public void DecrementSelection(int amount)
    {
        selectionCount -= amount;
        EnableButtons(true);
        int i = 15;
        while (amount > 0)
        {
            if (selection[i])
            {
                buttons[i].isOn = false;
                amount--;
            }

            if (--i < 0) { break; }
        }
        EnableButtons(false);
    }

    // When a button is clicked, that person turns on/off
    public void ToggleSprite(int index)
    {
        if (selection[index])
        {
            selection[index] = false;
            if (selectionCount++ == 0)
                EnableButtons(true);
        }
        else
        {
            selection[index] = true;
            if (--selectionCount == 0)
                EnableButtons(false);
        }

        selectionText.text = selectionCount.ToString();
    }

    // When the player has selected all people, prevents them from picking more
    void EnableButtons(bool state)
    {
        for (int i = 0; i < 16; i++)
        {
            if (!selection[i])
                buttons[i].interactable = state;
        }
    }
}
