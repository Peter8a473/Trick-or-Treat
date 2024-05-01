using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMatrix : MonoBehaviour
{
    private Button[] outfitButtons = new Button[16];

    void Awake()
    {
        ArrangeOutfitButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ArrangeOutfitButtons()
    {
        GetOutfitButtons();
        for (int i = 0; i < 16; i++)
        {
            Debug.Log(i + ": " + outfitButtons[i].gameObject.transform.position);
        }
    }
    
    void GetOutfitButtons()
    {
        outfitButtons = GetComponentsInChildren<Button>();
    }
}
