using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    const int FULL = 1;
    const int EMPTY = 0;   
    const bool INVALID = false;
    const bool VALID = true;

    int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI doorText;

    //Records the outfit/door combinations
    public int[,] outfitCheck = new int[4, 5];

    //Sets the amount of times a person can answer the door
    int doorPrincess = 5;
    int doorRobot = 5;
    int doorSpider = 5;
    int doorVampire = 5;

    //Sets the outfit/door
    int door;
    int outfit;
    int random;
    bool isInput;

    void Start()
    {
        SetGame();
        PlayRound();
    }

    void Update()
    {
        scoreText.text = score.ToString();

        if (isInput)
        {
            isInput = false;
            if (CheckOutfit())
            {
                PlayRound();
            }
        }
    }

    //Resets variables for another game
    void SetGame()
    {
        score = 0;
        doorPrincess = 5;
        doorRobot = 5;
        doorSpider = 5;
        doorVampire = 5;
        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 5; ++j)
            {
                outfitCheck[i, j] = EMPTY;
            }
        }
    }

    //Completes a single round of play
    void PlayRound()
    {
        SetDoor();
    }

    //Assigns a person to go to the door
    void SetDoor()
    {
        door = Random.Range(1,5);
        if(CheckDoor(door))
        {
            switch (door) 
            {
                case 1:
                doorText.text = "Princess";
                doorPrincess--;
                break;

                case 2:
                doorText.text = "Robot";
                doorRobot--;
                break;

                case 3:
                doorText.text = "Spider";
                doorSpider--;
                break;

                case 4:
                doorText.text = "Vampire";
                doorVampire--;
                break;

                default:
                SetDoor();
                break;
            }
        }
        else
        {
            SetDoor();
        }
    }

    //Makes sure that one person doesn't occur 5+ times
    bool CheckDoor(int door)
    {
        if((door == 1) && (doorPrincess == 0))
        {
            return INVALID;
        }
        else if((door == 2) && (doorRobot == 0))
        {
            return INVALID;
        }
        else if((door == 3) && (doorSpider == 0))
        {
            return INVALID;
        }
        else if((door == 4) && (doorVampire == 0))
        {
            return INVALID;
        }
        else
        {
            return VALID;
        }
    }

    //Interprets the player input
    public void SetOutfit(int input)
    {
        outfit = input;
        isInput = true;
    }

    //Checks the outfit/door combination
    bool CheckOutfit()
    {
        if (outfitCheck[door - 1, outfit - 1] == EMPTY)
        {
            outfitCheck[door - 1, outfit - 1] = FULL;
            score++;
            return VALID;
        }
        else
        {
            return INVALID;
        }
    }
}
