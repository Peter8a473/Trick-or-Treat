using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Player;
    [SerializeField] private Transform StartMarker;
    [SerializeField] private Transform EndMarker;
    [SerializeField] private float countTime = 5.0f;
    Vector2 destination;

    public GameManager GM;

    public void Start()
    {
        SetColor(Player, Color.gray);
    }

    public void SetStart()
    {
        destination = StartMarker.transform.position;
    }

    public void Update()
    {
        transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime);
    }

    //When BUNNY outfit is selected
    public void OnBunny()
    {
        SetColor(Player, Color.green);
        GM.SetOutfit(1);
    }

    //When BIRD outfit is selected
    public void OnBird()
    {
        SetColor(Player, Color.red);
        GM.SetOutfit(2);
    }

    //When DOG outfit is selected
    public void OnDog()
    {
        SetColor(Player, Color.yellow);
        GM.SetOutfit(3);
    }

    //When FISH outfit is selected
    public void OnFish()
    {
        SetColor(Player, Color.blue);
        GM.SetOutfit(4);
    }

    //When CAT outfit is selected
    public void OnCat()
    {
        SetColor(Player, Color.black);
        GM.SetOutfit(5);
    }

    //When ANY outfit is selected
    public void OnOutfit()
    {
        destination = EndMarker.transform.position;
    }

    void SetColor(SpriteRenderer sprite, Color color)
    {
        sprite.color = color;
    }
}
