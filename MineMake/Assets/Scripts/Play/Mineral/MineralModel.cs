using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralModel : MonoBehaviour
{
    public event EventHandler OnMineralLifeBelowZero;

    public List<MineralData> mineralDataPool;
    public List<MineralData> mineralDataList;

    
    public void Init()
    {

        InitMineralDataList(); 
    }

  
    public MineralData GetMineralData()
    {
        if (mineralDataPool.Count <= 0)
            throw new Exception();

        MineralData md = mineralDataPool[0];
        mineralDataPool.RemoveAt(0);

        mineralDataList.Add(md);

        return md;
    }

    private void InitMineralDataList()
    {
        mineralDataList = new List<MineralData>();

        mineralDataPool = new List<MineralData>();

        for(int i = 0; i < 30;i++)
        {
            MineralData md = new MineralData(i);
            md.OnMineralLifeBelowZero += Md_OnMineralLifeBelowZero;
            mineralDataPool.Add(md);
        }
    }

    public MineralData GetActivatedMineralDataUsingIndex(int _mineralIndex)
    {
        if (_mineralIndex < 0 || _mineralIndex >= mineralDataList.Count)
            throw new Exception();

        MineralData md = mineralDataList[_mineralIndex];

        return md; 
    }
    public int GetActivatedMineralDataUsingIndex(MineralData _md)
    {
        int index = -1;

        for(int i = 0; i < mineralDataList.Count;i++)
        {
            MineralData md = mineralDataList[i];

            if (md.id == _md.id)
            {
                index = i;
                break;
            }
        }

        return index;
    }

    public void RemoveMineralData(MineralData md)
    {
        mineralDataList.Remove(md);
        mineralDataPool.Add(md);
    }

    private void Md_OnMineralLifeBelowZero(object sender, EventArgs e)
    {
        OnMineralLifeBelowZero(sender, e);
    }

}
