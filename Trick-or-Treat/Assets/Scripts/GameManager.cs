using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    const int FULL = 1;
    const int EMPTY = 0;   
    const bool INVALID = false;
    const bool VALID = true;
    const bool OFF = false;
    const bool ON = true;

    //UI
    int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI doorText;
    public GameObject Check;

    //InputButtons
    public GameObject BunnyButton;
    public GameObject BirdButton;
    public GameObject DogButton;
    public GameObject FishButton;
    public GameObject CatButton;

    //Records the outfit/door combinations
    public int[,] outfitCheck = new int[4, 5];

    //Sets the amount of times a person can answer the door
    int doorPrincess = 5;
    int doorRobot = 5;
    int doorSpider = 5;
    int doorVampire = 5;
    bool princessSafe = OFF;
    bool robotSafe = OFF;
    bool spiderSafe = OFF;
    bool vampireSafe = OFF;

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
                StartCoroutine(DoCheck1a());
                StartCoroutine(DoCheck2());
            }
            //Loses Game
            else
            {
                StartCoroutine(DoCheck1b());
            }
        }
    }

    //Resets variables for another game
    void SetGame()
    {
        Check.SetActive(false);
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
        EnableButtons(ON);
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
        //Wins Game
        else if(princessSafe && robotSafe && spiderSafe && vampireSafe)
        {
            SceneManager.LoadScene("MainMenu");
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
            princessSafe = ON;
            return INVALID;
        }
        else if((door == 2) && (doorRobot == 0))
        {
            robotSafe = ON;
            return INVALID;
        }
        else if((door == 3) && (doorSpider == 0))
        {
            spiderSafe = ON;
            return INVALID;
        }
        else if((door == 4) && (doorVampire == 0))
        {
            vampireSafe = ON;
            return INVALID;
        }
        else
        {
            princessSafe = OFF;
            robotSafe = OFF;
            spiderSafe = OFF;
            vampireSafe = OFF;
            return VALID;
        }
    }

    //Interprets the player input
    public void SetOutfit(int input)
    {
        EnableButtons(OFF);
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

    void EnableButtons(bool invert)
    {
        if(invert)
        {
            BunnyButton.SetActive(ON);
            BirdButton.SetActive(ON);
            DogButton.SetActive(ON);
            FishButton.SetActive(ON);
            CatButton.SetActive(ON);
        }
        else
        {
            BunnyButton.SetActive(OFF);
            BirdButton.SetActive(OFF);
            DogButton.SetActive(OFF);
            FishButton.SetActive(OFF);
            CatButton.SetActive(OFF);
        }
    }

    void SetColor(SpriteRenderer sprite, Color color)
    {
        sprite.color = color;
    }

    //When completed a round
    IEnumerator DoCheck1a()
    {
        yield return new WaitForSeconds(1.0f);
        Check.SetActive(true);
    }

    //When failed a round
    IEnumerator DoCheck1b()
    {
        yield return new WaitForSeconds(1.0f);
        Check.SetActive(true);
        SceneManager.LoadScene("MainMenu");
    }

    //Sets up the next round
    IEnumerator DoCheck2()
    {
        yield return new WaitForSeconds(2.0f);
        Check.SetActive(false);
        PlayRound();
    }
}
