using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    private static BGManager inst;


    public static BGManager Inst { get => inst; }
    public BGManager() { inst = this; }

    public BGModel model;
    public BGView view;

    public float bgMovingDistance;      // 이후에 움직이는 거리

    private void Awake()
    {
        model.Init();
        view.Init(model);

        bgMovingDistance = 10.0f;

        InputManager.Inst.onBGClicked += Inst_onBGClicked;
    }



    private void Inst_onBGClicked(object sender, System.EventArgs e)
    {
        MoveBG(bgMovingDistance);
    }

    /// <summary>
    /// 오브젝트 90도 돌아가 있어서
    /// 현재 x값을 변경하면 Y값이 변경되어서 위로 올라가는 것처럼 보임
    /// </summary>
    /// <param name="distance"></param>
    private void MoveBG(float distance)
    {
        for (int i = 0; i < view.bgList.Count; i++)
        {
            BG bg = view.bgList[i];
            bg.transform.Translate(new Vector3(distance, 0, 0));
        }

        if (CheckFirstBGOutOfScreen())
            SendFirstBGToLast();

    }
    private bool CheckFirstBGOutOfScreen()
    {
        BG firstBG = view.bgList[0];

        if (CoordiManager.upperRight.y <= firstBG.transform.position.y - (view.BGHeight*0.5f))
            return true;

        return false;
    }
    private void SendFirstBGToLast()
    {
        BG lastBG = view.bgList[2];
        BG firstBG = view.bgList[0];

        view.bgList.RemoveAt(0);

        float changedY = lastBG.transform.position.y - view.BGHeight;
        firstBG.transform.position = new Vector3
            (
                firstBG.transform.position.x,
                changedY,
                0
            );

        view.bgList.Add(firstBG);
    }
}
