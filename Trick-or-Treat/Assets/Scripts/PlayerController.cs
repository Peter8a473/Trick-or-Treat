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

    public void Start()
    {
        SetColor(Player, Color.gray);
        StartCoroutine(Counter(countTime));
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
    }

    //When BIRD outfit is selected
    public void OnBird()
    {
        SetColor(Player, Color.red);
    }

    //When DOG outfit is selected
    public void OnDog()
    {
        SetColor(Player, Color.yellow);
    }

    //When FISH outfit is selected
    public void OnFish()
    {
        SetColor(Player, Color.blue);
    }

    //When CAT outfit is selected
    public void OnCat()
    {
        SetColor(Player, Color.black);
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

    IEnumerator Counter(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        destination = StartMarker.transform.position;
        SetColor(Player, Color.gray);
    }
}
