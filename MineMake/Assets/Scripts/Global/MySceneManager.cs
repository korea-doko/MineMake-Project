using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class MySceneManager : MonoBehaviour
{

    
    public enum ESceneType
    {
        Loading,
        Lobby,
        Play
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static void ChangeSceneTo(ESceneType _type)
    {    
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)_type);        
    }       
}
