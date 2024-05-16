using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderPopup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject Popup;
    bool visible;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Popup.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) 
    {  
        Popup.SetActive(false);
    }
}
