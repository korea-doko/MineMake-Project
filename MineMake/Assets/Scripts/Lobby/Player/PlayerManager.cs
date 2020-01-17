using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private static PlayerManager inst;
    public static PlayerManager Inst { get => inst; }
    public PlayerManager() { inst = this; }

    public PlayerView view;
    public PlayerModel model;

    private void Awake()
    {
        model.Init();
        view.Init(model);

        
        MySceneManager.Inst.onLobbySceneLoaded += Inst_onLobbySceneLoaded;
        MySceneManager.Inst.onUnloadLobbyScene += Inst_onUnloadLobbyScene;
    }

    private void Update()
    {
        if( Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(" Player 정보 초기화");

            PlayerResource pr = new PlayerResource();
            SaveLoadManager.SavePlayerResource(pr);
        }
    }


    private void Inst_onUnloadLobbyScene(object sender, System.EventArgs e)
    {
        DataPassManager.Inst.playerPower = model.power;
    }

    private void Inst_onLobbySceneLoaded(object sender, System.EventArgs e)
    {

        PlayerResource pr = SaveLoadManager.LoadPlayerResource();

        if (pr != null)
        {
            model.playerResource = new PlayerResource(pr);

            if (DataPassManager.Inst.rewardData != null)
            {
                model.AddRewardData(DataPassManager.Inst.rewardData);
                DataPassManager.Inst.rewardData = null;

                SaveLoadManager.SavePlayerResource(model.playerResource);
            }
        }
        else
        {
            SaveLoadManager.SavePlayerResource(model.playerResource);
            Debug.Log("파일이 없어서 기본 값 저장");
        }
    }  
}
