using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralView : MonoBehaviour
{
    public event EventHandler OnMineralHit;

    public List<Mineral> mineralPool;
    public List<Mineral> mineralList;

    public void Init(MineralModel model)
    {
        mineralList = new List<Mineral>();

        InitMineralPool();
    }

    public Mineral GetMineral()
    {
        if (mineralPool.Count <= 0)
            throw new Exception();

        Mineral m = mineralPool[0];
        mineralPool.RemoveAt(0);

        return m;
    }

    public void ShowMineral(Mineral _mineral, Vector3 _pos)
    {
        _mineral.Show(_pos);
        mineralList.Add(_mineral);
    }

    public int GetActivatedMineralIndex(Mineral _mineral)
    {
        int index = -1;

        for(int i = 0; i < mineralList.Count; i++)
        {
            Mineral m = mineralList[i];

            if (m.id == _mineral.id)
            {
                index = i;
                break;
            }
        }

        return index;
    }


    private void InitMineralPool()
    {
        mineralPool = new List<Mineral>();

        GameObject mineralPrefab = Resources.Load("Mineral") as GameObject;

        for(int i = 0; i < 30 ; i++)
        {
            Mineral m = ((GameObject)Instantiate(mineralPrefab)).GetComponent<Mineral>();
            m.Init(i);
            m.OnMineralHit += M_OnMineralHit;

            m.transform.SetParent(this.transform);
            mineralPool.Add(m);
        }
    }

    public Mineral GetActivatedMineralUsingIndex(int _mineralDataIndex)
    {
        if (_mineralDataIndex < 0 || _mineralDataIndex >= mineralList.Count)
            throw new Exception();

        Mineral m = mineralList[_mineralDataIndex];
        return m;
    }

    public void RemoveMineral(Mineral m)
    {
        m.Hide();
        this.mineralList.Remove(m);
        this.mineralPool.Add(m);
    }

    private void M_OnMineralHit(object sender, EventArgs e)
    {
        OnMineralHit(sender, e);
    }
}
