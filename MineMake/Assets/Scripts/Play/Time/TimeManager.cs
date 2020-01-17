﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager inst;

    public static TimeManager Inst { get => inst; }
    public TimeManager() { inst = this; }


    public TimeModel model;
    public TimeView view;

    public float maxTime;
    public float curTime;

    private void Awake()
    {
        model.Init();
        view.Init(model);

        maxTime = curTime = 3.0f;
    }

    private void Update()
    {
        curTime = curTime - Time.deltaTime;

        float ratio = curTime / maxTime;

        if( curTime <= 0)
        {
            Debug.Log(" 시간 초과 ");

            MySceneManager.ChangeSceneTo(MySceneManager.ESceneType.Lobby);
        }

        view.ChangeGaugeRatio(ratio);
    } 
}