using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class DataPassManager : MonoBehaviour
{
  


    private static DataPassManager inst;
    public static DataPassManager Inst { get => inst; }
    public DataPassManager() { inst = this; }


    // 저장할 데이터
    public MineData chosenMineData;
    public int playerPower;
    
    public RewardData rewardData;



    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        chosenMineData = null;
        playerPower = -1;
        rewardData = null;
    }

}
