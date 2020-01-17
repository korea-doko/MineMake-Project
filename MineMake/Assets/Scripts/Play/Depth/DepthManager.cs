using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthManager : MonoBehaviour
{
    private static DepthManager inst;

    public static DepthManager Inst { get => inst; }
    public DepthManager() { inst = this; }

    public DepthModel model;
    public DepthView view;

    private void Awake()
    {
        model.Init();
        view.Init(model);
    }

    public void IncreaseDepth(int depth)
    {
        model.depth += depth;


        ChangeDepthPanel();
    }
    private void ChangeDepthPanel()
    {
        view.ChangeDepthPanel(model.depth);
    }
}
