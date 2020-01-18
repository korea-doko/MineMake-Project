using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputView : MonoBehaviour
{
    public event EventHandler onDroppingDirtIsOver;

    public List<DroppingDirt> droppingDirtPool;
    public List<DroppingDirt> droppingDirtList;

    public void Init(InputModel model)
    {
        InitDroppingDirtList();
    }

    private void InitDroppingDirtList()
    {
        droppingDirtList = new List<DroppingDirt>();
        droppingDirtPool = new List<DroppingDirt>();

        GameObject dirtPrefab = Resources.Load("DroppingDirt") as GameObject;

        for(int i = 0; i < 50; i++)
        {
            DroppingDirt dd = ((GameObject)Instantiate(dirtPrefab)).GetComponent<DroppingDirt>();

            dd.Init(i);
            dd.onParticleDurationIsOver += Dd_onParticleDurationIsOver;
            dd.transform.SetParent(this.transform);
            droppingDirtPool.Add(dd);
        }
    }


    public DroppingDirt GetDroppingDirt()
    {
        if (droppingDirtPool.Count <= 0)
            throw new Exception();

        DroppingDirt dd = droppingDirtPool[0];
        droppingDirtPool.RemoveAt(0);

        droppingDirtList.Add(dd);

        return dd;
    }


    private void Dd_onParticleDurationIsOver(object sender, EventArgs e)
    {
        DroppingDirt dd = (DroppingDirt)sender;
        dd.Hide();

        droppingDirtList.Remove(dd);
        droppingDirtPool.Add(dd);

        //onDroppingDirtIsOver(sender, e);
    }
}
