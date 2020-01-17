using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    private static RewardManager inst;

    public static RewardManager Inst { get => inst; }
    public RewardManager() { inst = this; }
    public RewardModel model;
    public RewardView view;

    private void Awake()
    {
        model.Init();
        view.Init(model);

        view.onRewardPanelConfirmButtonClicked += View_onRewardPanelConfirmButtonClicked;

        MySceneManager.Inst.onUnloadPlayScene += Inst_onUnloadPlayScene;
    }

    private void Inst_onUnloadPlayScene(object sender, EventArgs e)
    {
        DataPassManager.Inst.rewardData = model.rewardData;
    }

    public void AddReward(MineralData md)
    {
        model.AddReward(md.mineralType,1);
    }

    public void ShowReward()
    {
        view.ShowReward(model);
    }


    private void View_onRewardPanelConfirmButtonClicked(object sender, EventArgs e)
    {
        // 리워드 버튼을 클릭했기 때문에 보상을 저장하고
        // 씬을 넘겨야함
       

        MySceneManager.ChangeSceneTo(MySceneManager.ESceneType.Lobby);
    }
 
}
