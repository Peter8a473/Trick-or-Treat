using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Costumes : MonoBehaviour
{
    public static Sprite[] costumeIMG = new Sprite[16];
    public static bool[] selection = new bool[16];

    int selectionCount;
    public TextMeshProUGUI selectionText;

    public Toggle[] buttons = new Toggle[16];

    void Awake()
    {
        for (int i = 0; i < 16; i++)
        {
            selection[i] = false;
            costumeIMG[i] = buttons[i].gameObject.GetComponentInChildren<Image>().sprite;
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        selectionCount = Customize.costumes;
        for (int i = 0; i < 16; i++)
            if (selection[i]) { selectionCount--; }

        selectionText.text = selectionCount.ToString();
    }

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

    void EnableButtons(bool state)
    {
        for (int i = 0; i < 16; i++)
        {
            if (!selection[i])
                buttons[i].interactable = state;
        }
    }
}
