using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerResource 
{
    [SerializeField] public int gold;
    [SerializeField] public int[] mineralValues;

    public PlayerResource()
    {
        gold = 0;
        mineralValues = new int[MineralData.NumberOfMineralType];
    }
    public PlayerResource(PlayerResource _pr)
    {
        gold = _pr.gold;

        mineralValues = new int[MineralData.NumberOfMineralType];        
        for(int i = 0; i < MineralData.NumberOfMineralType;i++)
            mineralValues[i] = _pr.mineralValues[i];
       
    }
}
