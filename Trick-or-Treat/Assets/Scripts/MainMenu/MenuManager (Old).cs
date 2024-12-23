using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerOld : MonoBehaviour
{
    void Start()
    {

    }

    public void OnPlay(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
