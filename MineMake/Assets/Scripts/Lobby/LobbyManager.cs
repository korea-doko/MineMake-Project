using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    private static LobbyManager inst;

    public static LobbyManager Inst { get => inst; }
    public LobbyManager()
    {
        inst = this;
    }

    private void Awake()
    {
        

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            MySceneManager.ChangeSceneTo(MySceneManager.ESceneType.Play);
    }
}
