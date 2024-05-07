using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratio : MonoBehaviour
{
    public static float currentWidth; // Screen Width
    public static float idealWidth = 520f;

    // Start is called before the first frame update
    void Awake()
    {
        currentWidth = Screen.width;
        Debug.Log(idealWidth / currentWidth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
