using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fn : MonoBehaviour
{
    public static int RandomInt(int minInclusive, int maxExclusive)
    {
        return Random.Range(minInclusive, maxExclusive);
    }

    public static int RandomOfInts(int[] arr)
    {
        return arr[Random.Range(0, arr.Length)];
    }
}
