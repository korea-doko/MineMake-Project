using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardModel : MonoBehaviour
{
    public RewardData rewardData;
    
    
    public void Init()
    {
        rewardData = new RewardData();
    }

    public void AddReward(EMineralType _type, int _value)
    {
        rewardData.AddReward(_type, _value);
    }
}
