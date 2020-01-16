using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{

    private static LoadingManager inst;

    public static LoadingManager Inst { get => inst;  }
    public LoadingManager(){ inst = this; }

    void Start()
    {
        
    }

    private void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space))
            MySceneManager.ChangeSceneTo(MySceneManager.ESceneType.Lobby);
        
    }
}
