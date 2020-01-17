using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class DataPassManager : MonoBehaviour
{
    public enum ESceneChangedType
    {
        LobbyToPlay,
        PlayToLobby
    }
    public event EventHandler onSceneLobbyToPlay;

    public event EventHandler onScenePlayToLobby;

    private static DataPassManager inst;
    public static DataPassManager Inst { get => inst; }
    public DataPassManager() { inst = this; }


    // 저장할 데이터
    public MineData chosenMineData;
    public int playerPower;
    
    public RewardData rewardData;



    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.sceneUnloaded += SceneManager_sceneUnloaded;
    }



    private void SceneManager_sceneUnloaded(Scene _scene)
    {
        if (_scene.name == "LoadingScene")
        {
            Debug.Log("로딩씬 언로드");
        }
        if (_scene.name == "LobbyScene")
        {
            Debug.Log(onSceneLobbyToPlay.GetInvocationList().Length);
            onSceneLobbyToPlay(this, EventArgs.Empty);
            onSceneLobbyToPlay = null;

          //  Debug.Log("로비씬 언로드");
        }
        if (_scene.name == "PlayScene")
        {
            Debug.Log("플레이씬 언로드");
            onScenePlayToLobby(this, EventArgs.Empty);
            onScenePlayToLobby = null;
        }
    }

    private void SceneManager_sceneLoaded(Scene _scene, LoadSceneMode arg1)
    {


        if (_scene.name == "LoadingScene")
            Debug.Log("로딩");

        if (_scene.name == "LobbyScene")
        {
         //   onSceneLobbyToPlay = null;
         
        }

        if(_scene.name == "PlayScene")
        {
            Debug.Log("플레이");
        }

    }
}
