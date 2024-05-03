using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilhouetteHandler : MonoBehaviour
{
    public static SilhouetteHandler Instance;

    [SerializeField] GameObject silhouette;
    [SerializeField] private Sprite[] silhouetteSprites = new Sprite[16];

    [SerializeField] Vector2 startPos;
    [SerializeField] Vector2 endPos;

    [SerializeField] float baseSpeed;
    [SerializeField] float skipSpeed;
    float speed;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            SpeedUp();
        }
    }

    public void Go(int index)
    {
        StartCoroutine(WindowWalk(index));
    }

    IEnumerator WindowWalk(int index)
    {
        speed = baseSpeed;
        silhouette.transform.position = startPos;
        silhouette.GetComponent<Image>().sprite = silhouetteSprites[index];
        while (silhouette.transform.position.x > endPos.x)
        {
            silhouette.transform.Translate(Vector2.left * Time.deltaTime * speed);
            yield return null;
        }
    }
    // Update is called once per frame
    public void SpeedUp()
    {
        speed = skipSpeed;
    }
}
