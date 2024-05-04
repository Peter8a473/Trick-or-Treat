using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnPlay(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
