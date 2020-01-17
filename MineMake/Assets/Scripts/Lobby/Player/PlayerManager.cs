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

        DataPassManager.Inst.onSceneLobbyToPlay += DataPassManager_onSceneLobbyToPlay;
    }

    private void DataPassManager_onSceneLobbyToPlay(object sender, System.EventArgs e)
    {
        DataPassManager.Inst.playerPower = model.power;
    }
}
