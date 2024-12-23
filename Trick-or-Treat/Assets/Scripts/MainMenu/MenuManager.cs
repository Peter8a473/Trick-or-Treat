using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    GameObject MainPanel;
    GameObject BasicPanel;
    GameObject AdvancedPanel;
    GameObject SettingsPanel;
    GameObject DimPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSettings() {
        Debug.Log("Settings");
    }

    public void OnPlay() {
        StartCoroutine();
    }

    public IEnumerator On2Play() {
        Debug.Log("Play2");
        return null;
    }
}
