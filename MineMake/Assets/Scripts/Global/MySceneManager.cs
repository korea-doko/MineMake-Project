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

    private static MySceneManager inst;
    public static MySceneManager Inst { get => inst; }
    public MySceneManager() { inst = this; }
    
    public event EventHandler onLobbySceneLoaded;

    public event EventHandler onUnloadLobbyScene;
    public event EventHandler onUnloadPlayScene;

    
    

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.sceneUnloaded += SceneManager_sceneUnloaded;

    }

    public static void ChangeSceneTo(ESceneType _type)
    {    
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)_type);        
    }

    private void SceneManager_sceneUnloaded(Scene _scene)
    {
        if (_scene.name == "LoadingScene")
        {
            Debug.Log("로딩씬 언로드");
        }
        if (_scene.name == "LobbyScene")
        {
            Debug.Log(onUnloadLobbyScene.GetInvocationList().Length);
            onUnloadLobbyScene(this, EventArgs.Empty);
            onUnloadLobbyScene = null;

              Debug.Log("로비씬 언로드");
        }
        if (_scene.name == "PlayScene")
        {
            Debug.Log("플레이씬 언로드");
            onUnloadPlayScene(this, EventArgs.Empty);
            onUnloadPlayScene = null;
        }
    }

    private void SceneManager_sceneLoaded(Scene _scene, LoadSceneMode arg1)
    {


        if (_scene.name == "LoadingScene")
            Debug.Log("로딩");

        if (_scene.name == "LobbyScene")
        {
            Debug.Log("로비");
            onLobbySceneLoaded(this, EventArgs.Empty);
        }           
        if (_scene.name == "PlayScene")
        {
            Debug.Log("플레이");
        }

    }
}
