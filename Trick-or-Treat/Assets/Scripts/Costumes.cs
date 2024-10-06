using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Costumes : MonoBehaviour
{
    public static Costumes Instance;

    public static Sprite[] costumeIMG = new Sprite[16];
    public static bool[] selection = new bool[16];

    public int selectionCount;
    public TextMeshProUGUI selectionText;

    public Toggle[] buttons = new Toggle[16];

    void Start()
    {
        Instance = this;

        for (int i = 0; i < 16; i++)
        {
            selection[i] = false; // Sets all costumes to false
            Image[] temp = buttons[i].gameObject.GetComponentsInChildren<Image>(); // Retrieves the sprites for a static variable
            costumeIMG[i] = temp[1].sprite;
        }

        // If there are costumes saved, load them
        if (PlayerPrefs.GetInt("CostumesSaved") == 1) { LoadCostumes(); }
        else { Default(); SaveCostumes(); PlayerPrefs.SetInt("CostumesSaved", 1); }
    }
    
    void Update()
    {
        if (Input.GetKeyDown("r"))
            PlayerPrefs.SetInt("CostumesSaved", 0);
    }

    // Initializes the costumes to a default state
    void Default()
    {
        selectionCount = 4;
        EnableButtons(true);
        for (int i = 0; i < 4; i++)
        {
            buttons[i].isOn = true;
        }
        selectionText.text = selectionCount.ToString();
        EnableButtons(false);
    }

    public void LoadCostumes()
    {
        // Retrieve Data //
        selectionCount = Customize.costumes;
        for (int i = 0; i < 16; i++)
        {
            if (PlayerPrefs.GetInt("costume " + i.ToString()) == 1)
            {
                buttons[i].isOn = true;
            }
        }

        selectionText.text = selectionCount.ToString();
        EnableButtons(false);
    }

    public void SaveCostumes()
    {
        int h = 0;
        while (selectionCount > 0)
        {
            if (!selection[h])
            {
                buttons[h].isOn = true;
            }
            h++;
        }

        for (int i = 0; i < 16; i++)
        {
            if (selection[i]) { PlayerPrefs.SetInt("costume " + i.ToString(), 1); }
            else { PlayerPrefs.SetInt("costume " + i.ToString(), 0); }
        }
    }

    // Adjusts the selection if the costume amount increases
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

    // Adjusts the selection if the costume amount decreases
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

    // When a button is clicked, that costume turns on/off
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

    // When the player has selected all costumes, prevents them from picking more
    void EnableButtons(bool state)
    {
        for (int i = 0; i < 16; i++)
        {
            if (!selection[i])
                buttons[i].interactable = state;
        }
    }
}
