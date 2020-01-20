using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineManager : MonoBehaviour
{
    private static MineManager inst;

    public static MineManager Inst { get => inst; }
    public MineManager() { inst = this; }

    [SerializeField] private MineModel model;
    [SerializeField] private MineView view;

    [SerializeField] MineData chosenMineData;
    

    private void Awake()
    {
        model.Init();
        view.Init(model);
        view.onMinePanelClicked += View_onMinePanelClicked;

        MySceneManager.Inst.onUnloadLobbyScene += Inst_onUnloadLobbyScene;        
    }

    private void Inst_onUnloadLobbyScene(object sender, System.EventArgs e)
    {
        DataPassManager.Inst.chosenMineData = this.chosenMineData;
    }

    public void HideMine()
    {
        view.Hide();
    }

    public void ShowMine()
    {
        view.ShowMine(model);
    }

    private void View_onMinePanelClicked(object sender, System.EventArgs e)
    {
        MinePanel mp = (MinePanel)sender;
        
        this.chosenMineData = model.GetMineData(mp.id);
       
        // f12누르면 함수로 다이빙
        // DataPassManager에 선택한 것 저장
        // DataPassManager.Inst.chosenMineData = md;
        

        MySceneManager.ChangeSceneTo(MySceneManager.ESceneType.Play);
    }
}
