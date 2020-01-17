using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RewardData 
{
    public int[] rewardValues;

    public int testVariable;

    public RewardData()
    {
        testVariable = 0;
        rewardValues = new int[MineralData.NumberOfMineralType];
    }

    public void AddReward(EMineralType _type, int _value)
    {
        testVariable++;

        rewardValues[(int)_type] += _value;
    }
}
