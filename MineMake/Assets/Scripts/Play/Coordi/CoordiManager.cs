using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordiManager : MonoBehaviour
{

    [SerializeField] public static Vector3 lowerLeft;

    [SerializeField] public static Vector3 upperRight;

    private void Awake()
    {
        lowerLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        upperRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    public static Vector3 GetRandWorldPosInSeenView()
    {
        float randomX = UnityEngine.Random.Range(lowerLeft.x, upperRight.x);
        float randomY = UnityEngine.Random.Range(lowerLeft.y, upperRight.y);

        return new Vector3(randomX, randomY);

    }
}
