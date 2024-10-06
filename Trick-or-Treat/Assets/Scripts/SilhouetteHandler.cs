using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilhouetteHandler : MonoBehaviour
{
    public static SilhouetteHandler Instance;

    [SerializeField] GameObject silhouette;
    [SerializeField] private Sprite[] silhouetteSprites = new Sprite[16];
    private int[] newIndexes = new int[16];

    [SerializeField] Vector2 startPos;
    [SerializeField] Vector2 endPos;

    [SerializeField] float baseSpeed;
    [SerializeField] float skipSpeed;
    float speed;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        ArrayOfNewIndexes();
    }

    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            SpeedUp();
        }
    }

    void ArrayOfNewIndexes()
    {
        int temp = 0;
        for (int i = 0; i < 16; i++)
        {
            if (temp == Customize.people)
                break;

            if (People.selection[i])
            {
                newIndexes[temp] = i;
                temp++;
            }
        }
    }

    public void Go(int index)
    {
        StartCoroutine(WindowWalk(index));
    }

    IEnumerator WindowWalk(int index)
    {
        speed = baseSpeed / GameManager.Instance.timerDuration;
        silhouette.transform.position = startPos;
        silhouette.GetComponent<Image>().sprite = People.personIMG[newIndexes[index]];
        while (silhouette.transform.position.x > endPos.x)
        {
            silhouette.transform.Translate(Vector2.left * Time.deltaTime * speed);
            yield return null;
        }
    }
    
    public void SpeedUp()
    {
        speed = skipSpeed / GameManager.Instance.timerDuration;
    }
}
