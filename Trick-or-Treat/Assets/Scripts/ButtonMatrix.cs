using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMatrix : MonoBehaviour
{
    public static ButtonMatrix Instance;

    [SerializeField] public Button[] outfitButtons = new Button[16];
    private float buttonSize = 105f;
    private Vector2[] refPosition = 
    {
        new Vector2(126.75f, 168.67f),

        new Vector2(108f, 150f),
        new Vector2(108f, 150f),

        new Vector2(108f, 187.5f),
        new Vector2(108f, 187.5f),
        new Vector2(108f, 187.5f),

        new Vector2(98.67f, 168.67f),
        new Vector2(98.67f, 168.67f),
        new Vector2(98.67f, 168.67f),
        
        new Vector2(98.67f, 196.75f),
        new Vector2(98.67f, 196.75f),
        new Vector2(98.67f, 196.75f),
        new Vector2(98.67f, 196.75f)
    };

    public int refInt = 4;

    void Awake()
    {
        Instance = this;
        refInt = GameManager.Instance.costumes;
        ArrangeOutfitButtons();
    }

    void Update()
    {

    }

    void ArrangeOutfitButtons()
    {
        GetOutfitButtons();
        
        int sqrt = GetSquareRoot(refInt);
        Vector2 pos = refPosition[refInt - 4];
        int k = 0;
        float increment = 0;
        float scale = 0;
        int fullRows = 0;     

        if (sqrt == 2)
        {
            increment = 112.5f;
            scale = 2f;
        }
        else if (sqrt == 3)
        {
            increment = 75f;
            scale = 4f / 3f;
        }
        else if (sqrt == 4) 
        {
            increment = 56f;
            scale = 1f;
        }

        int tempSqrt = sqrt;
        if (refInt == 5 || refInt == 10 || refInt == 11)
            tempSqrt--;
        fullRows = refInt % tempSqrt;
        if (fullRows == 0)
            fullRows = tempSqrt;

        while (k < refInt)
        {
            if (fullRows > 0)
            {
                k = FillRow(pos, sqrt, k, increment);
                fullRows--;
            }
            else
            {
                pos = new Vector2(pos.x + (increment / 2f), pos.y);
                k = FillRow(pos, sqrt - 1, k, increment);
                pos = new Vector2(pos.x - (increment / 2f), pos.y);
            }
            pos = new Vector2(pos.x, pos.y - increment);
        }

        for (int i = 0; i < 16; i++)
        {
            if (i < k)
            {
                outfitButtons[i].gameObject.transform.localScale = new Vector3 (scale, scale, 0f);
            }
            else
            {
                Destroy(outfitButtons[i].gameObject);
            }
        }
    }
    
    void GetOutfitButtons()
    {
        outfitButtons = GetComponentsInChildren<Button>();
    }

    int GetSquareRoot(int x)
    {
        if (x <= 4)
            return 2;
        else if (x <= 9)
            return 3;
        else if (x <= 16)
            return 4;
        else
            return 4;
    }

    int FillRow(Vector2 pos, int sqrt, int k, float increment)
    {
        for (int i = 0; i < sqrt; i++)
        {
            if (i != 0)
                pos = new Vector2(pos.x + increment, pos.y);
            outfitButtons[k++].gameObject.transform.position = pos;
        }
        return k;
    }

    public void ToggleButtons(bool state)
    {
        foreach (Button button in outfitButtons)
        {
            if (button != null)
                button.gameObject.SetActive(state);
        }
    }

    public void ButtonClick(int index)
    {
        GameManager.Instance.currentOutfitIndex = index;
    }
}
