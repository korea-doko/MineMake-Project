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



    private void Awake()
    {
        model.Init();
        view.Init(model);
        view.onMinePanelClicked += View_onMinePanelClicked;
    }


    private void Update()
    {
        if( Input.GetKeyDown(KeyCode.M))
        {
            ShowMineInfo();
        }
    }

    public void ShowMineInfo()
    {
        view.ShowMine(model);
    }



    private void View_onMinePanelClicked(object sender, System.EventArgs e)
    {
        MinePanel mp = (MinePanel)sender;
        
        MineData md = model.GetMineData(mp.id);
       

        // DataPassManager에 선택한 것 저장
        DataPassManager.Inst.chosenMineData = md;

        MySceneManager.ChangeSceneTo(MySceneManager.ESceneType.Play);
    }
}
