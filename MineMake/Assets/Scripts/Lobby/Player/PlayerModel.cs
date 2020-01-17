using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public PlayerResource playerResource;

    public int power;
   
    public void Init()
    {
        playerResource = new PlayerResource();

        power = 1;
    }

    public void AddRewardData(RewardData rewardData)
    {
        for (int i = 0; i < MineralData.NumberOfMineralType; i++)
            playerResource.mineralValues[i] += rewardData.rewardValues[i];
        
    }
}
