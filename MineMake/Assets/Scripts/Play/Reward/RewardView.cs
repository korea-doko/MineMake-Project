using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardView : MonoBehaviour
{
    public event EventHandler onRewardPanelConfirmButtonClicked;
    public RewardPanel rewardPanel;

    public void Init(RewardModel model)
    {
        rewardPanel.Init();

        rewardPanel.onButtonClicked += RewardPanel_onButtonClicked;
    }

    

    public void ShowReward(RewardModel model)
    {
        rewardPanel.Show(model);
    }

    private void RewardPanel_onButtonClicked(object sender, EventArgs e)
    {
        onRewardPanelConfirmButtonClicked(sender, e);
    }
}
