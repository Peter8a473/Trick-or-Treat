using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMatrix : MonoBehaviour
{
    public static ButtonMatrix Instance;

    [SerializeField] public Button[] outfitButtons = new Button[16];
    private float buttonSize = 105f;

    private float currentScale;
    private Vector2 currentPosition;

    private Vector2[] refPosition = new Vector2[13];

    public int refInt = 4;

    void Awake()
    {
        Instance = this;
        refInt = GameManager.Instance.costumes;

        currentPosition = gameObject.transform.position;
        currentScale = currentPosition.y * 2;
        
        AssignStartingPositions();

        ArrangeOutfitButtons();
    }

    void AssignStartingPositions()
    {
        // 2 x 2 Grid
        // (4)
        refPosition[0] = new Vector2 (currentPosition.x - (currentScale / 4), 3 * currentPosition.y / 2);

        // 3 x 3 Grid 
        // (9 -> 8, 7, *6, *5)
        refPosition[5] = new Vector2 (currentPosition.x - (currentScale / 3), 5 * currentPosition.y / 3);
        for (int i = 4; i > 0; i--)
            refPosition[i] = refPosition[5];

        for (int i = 2; i > 0; i--)
            refPosition[i] = new Vector2 (refPosition[i].x, refPosition[i].y - (currentScale / 6));

        // 4 x 4 Grid 
        // (16 -> 15, 14, 13, *12, *11, *10)
        refPosition[12] = new Vector2 (currentPosition.x - (3 * currentScale / 8), 7 * currentPosition.y / 4);
        for (int i = 11; i > 5; i--)
            refPosition[i] = refPosition[12];

        for (int i = 8; i > 5; i--)
            refPosition[i] = new Vector2 (refPosition[i].x, refPosition[i].y - (currentScale / 8));
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

        increment = currentScale / sqrt;
        scale = 4f / sqrt;    

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
