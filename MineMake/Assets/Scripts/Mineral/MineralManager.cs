using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralManager : MonoBehaviour
{
    private static MineralManager inst;

    public static MineralManager Inst { get => inst; }
    public MineralManager() { inst = this; }

    public MineralModel model;
    public MineralView view;

    
    private void Awake()
    {
        model.Init();
        view.Init(model);


        model.OnMineralLifeBelowZero += Model_OnMineralLifeBelowZero;
        view.OnMineralHit += View_OnMineralHit;
    }

  

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ShowMineral();
    }

    public void ShowMineral()
    {
        MineralData md = GetRandomMineralData();
        model.ActivateMineral(md);

        Mineral m = view.GetMineral();
                
        view.ShowMineral(m, Vector3.zero);
    }

   

    private MineralData GetRandomMineralData()
    {
        MineralData md = model.GetMineralData();

        md.mineralType = (EMineralType)(UnityEngine.Random.Range(0, MineralData.NumberOfMineralType));

        md.life = UnityEngine.Random.Range(5, 10);

        return md;
    }


    private void Model_OnMineralLifeBelowZero(object sender, EventArgs e)
    {
        MineralData md = (MineralData)sender;
        int dataIndex = model.GetActivatedMineralDataUsingIndex(md);
        
        Mineral m = view.GetActivatedMineralUsingIndex(dataIndex);


        model.RemoveMineralData(md);
        view.RemoveMineral(m);
    }

    private void View_OnMineralHit(object sender, EventArgs e)
    {
        Mineral m = (Mineral)sender;        
        int index= view.GetActivatedMineralIndex(m);
        
        MineralData md = model.GetActivatedMineralDataUsingIndex(index);
        md.GetDamaged(20);
        // 나중에 데미지는 20이 아니라 다르게 줘야 한다.

    }
}
