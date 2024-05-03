using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int costumes = 9;
    public int people = 4;
    bool[,] outfitCheck = new bool[16, 16];

    public int[] counter = new int[16];
    public int numCounter;
    public int currentDoorIndex = -1;
    public int currentOutfitIndex = -1;

    [SerializeField] float timerDuration;
    [SerializeField] Image timerWheel;
    bool skipped = false;

    [SerializeField] Image outfit;
    
    void Awake()
    {
        Instance = this;
        SetGame();
        StartCoroutine("PlayRound");
    }

    void SetGame()
    {
        numCounter = people;
        for (int i = 0; i < costumes; i++)
        {
            for (int j = 0; j < people; j++)
            {
                outfitCheck[i,j] = false;
                counter[j] = costumes;
            }
        }
    }

    IEnumerator PlayRound()
    {
        yield return new WaitForSeconds(0.5f);
        currentOutfitIndex = -1;
        outfit.sprite = null;

        bool cont = true;
        while (numCounter > 0)
        {
            currentDoorIndex = fn.RandomInt(0, people);
            if (counter[currentDoorIndex] > 0)
                break;
        }

        SilhouetteHandler.Instance.Go(currentDoorIndex);

        float timer = 0f;
        skipped = false;
        timerWheel.gameObject.SetActive(true);
        ButtonMatrix.Instance.ToggleButtons(true);
        while (timer < timerDuration && !skipped)
        {
            timerWheel.fillAmount = 1 - (timer / timerDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        timerWheel.gameObject.SetActive(false);
        ButtonMatrix.Instance.ToggleButtons(false);

        if (Check(currentOutfitIndex, currentDoorIndex))
        {
            if (numCounter <= 0)
            {
                Debug.Log("Won!");
            }
            else
            {
                StartCoroutine("PlayRound");
            }
        }
        else
        {
            Debug.Log("Lost!");
        }
    }

    public void SetOutfit()
    {
        outfit.sprite = ButtonMatrix.Instance.outfitButtons[currentOutfitIndex].GetComponent<Image>().sprite;
    }

    bool Check(int outfitIdx, int doorIdx)
    {
        if (outfitIdx < 0 || outfitCheck[outfitIdx,doorIdx])
            return false;

        outfitCheck[outfitIdx,doorIdx] = true;

        if (--counter[doorIdx] <= 0)
        {
            numCounter--;
        }

        return true;
    }


    int[] Swap(int[] arr, int index1, int index2)
    {
        int temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
        return arr;
    }

    public void Skip()
    {
        skipped = true;
        SilhouetteHandler.Instance.SpeedUp();
    }
}
