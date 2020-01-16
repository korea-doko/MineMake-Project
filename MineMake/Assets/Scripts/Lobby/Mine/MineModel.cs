using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineModel : MonoBehaviour
{
    public List<MineData> mineDataList;

    public void Init()
    {
        mineDataList = new List<MineData>();

        for(int i = 0; i < 10;i++)
        {
            MineData md = new MineData();
            md.testData =  UnityEngine.Random.Range(0, 100);
            mineDataList.Add(md);
        }
    }

    public MineData GetMineData(int index)
    {
        return mineDataList[index];
    }
}
