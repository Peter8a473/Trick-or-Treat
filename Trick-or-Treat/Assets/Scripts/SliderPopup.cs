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
        Debug.Log("Enter");
        Popup.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) 
    {  
        Debug.Log("Exit");
        Popup.SetActive(false);
    }
}
