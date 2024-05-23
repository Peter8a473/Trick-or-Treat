using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderPopup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject Popup;
    public float countdown = 0;
    public bool visible;
    public bool pointer;

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointer = true;
        TriggerPopup();
    }

    public void OnPointerExit(PointerEventData eventData) 
    {  
        pointer = false;
    }

    public void Slide()
    {
        countdown = 0.75f;
    }

    public void TriggerPopup()
    {
        if (!visible && gameObject.activeInHierarchy)
        {
            StartCoroutine(DisplayPopup());
        }
    }

    public IEnumerator DisplayPopup()
    {
        visible = true;
        Popup.SetActive(true);
        while (countdown >= 0)
        {
            countdown -= Time.deltaTime;
            if (pointer && countdown < 0)
                countdown = 0;
            
            yield return null;
        }
        Popup.SetActive(false);
        visible = false;
        countdown = 0;
    }

}
