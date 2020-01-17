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

    [SerializeField] private Vector3 lowerLeft;
    [SerializeField] private Vector3 upperRight;

    [SerializeField] private float maxRegenTime;
    [SerializeField] private float minRegenTime;
    [SerializeField] private int maxExistingMinerals;

    [SerializeField] private int depth;

    private void Awake()
    {
        model.Init();
        view.Init(model);


        lowerLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        upperRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        maxRegenTime = 5.0f;
        minRegenTime = 1.0f;
        maxExistingMinerals = 2;
        depth = 0;


        model.OnMineralLifeBelowZero += Model_OnMineralLifeBelowZero;
        view.OnMineralHit += View_OnMineralHit;




        StartCoroutine(GenerateMineral());
    }
    
    IEnumerator GenerateMineral()
    {       
        while(true)
        {
            float waitingTime = UnityEngine.Random.Range(minRegenTime, maxRegenTime);

            yield return new WaitForSeconds(waitingTime);

            if (model.mineralDataList.Count < maxExistingMinerals)
                ShowMineral();
        }
    }



    public void ShowMineral()
    {
        MineralData md = GetRandomMineralData();
        model.ActivateMineral(md);

        Mineral m = view.GetMineral();
        Vector3 randomPos = GetRandomMineralPos();

        view.ShowMineral(m, randomPos);
    }

    private Vector3 GetRandomMineralPos()
    {
        float randomX = UnityEngine.Random.Range(lowerLeft.x, upperRight.x);
        float randomY = UnityEngine.Random.Range(lowerLeft.y, upperRight.y);

        return new Vector3(randomX, randomY);
    }

    private MineralData GetRandomMineralData()
    {
        MineralData md = model.GetMineralData();

        md.mineralType = (EMineralType)(UnityEngine.Random.Range(0, MineralData.NumberOfMineralType));

        md.life = UnityEngine.Random.Range(5, 10);

        return md;
    }

    // EventHandlers are below
    private void Model_OnMineralLifeBelowZero(object sender, EventArgs e)
    {
        MineralData md = (MineralData)sender;
        int dataIndex = model.GetActivatedMineralDataUsingIndex(md);
        
        Mineral m = view.GetActivatedMineralUsingIndex(dataIndex);

        RewardManager.Inst.AddReward(md);

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
