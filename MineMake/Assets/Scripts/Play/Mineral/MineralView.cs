using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralView : MonoBehaviour
{
    public event EventHandler OnMineralHit;



    public List<Mineral> mineralPool;
    public List<Mineral> mineralList;

    public List<MineralIndicator> indicatorList;
    public List<MineralIndicator> indicatorPool;

    public void Init(MineralModel model)
    {        
        InitMineral();
        InitIndicator();
    }
    
    public void ShowMineral(Mineral _mineral, Vector3 _pos)
    {
        _mineral.Show(_pos);
    }
    public void ShowIndicator(MineralIndicator _mi, Vector3 _randPos)
    {
        _mi.Show(_randPos);
        
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

        mineralList.Remove(m);
        mineralPool.Add(m);
    }

    public Mineral GetMineral()
    {
        if (mineralPool.Count <= 0)
            throw new Exception();

        Mineral m = mineralPool[0];
        mineralPool.RemoveAt(0);
        mineralList.Add(m);

        return m;
    }
    public MineralIndicator GetIndicator()
    {
        if (indicatorPool.Count <= 0)
            throw new Exception();

        MineralIndicator mi = indicatorPool[0];
        indicatorPool.RemoveAt(0);

        indicatorList.Add(mi);

        return mi;
    }

    private void InitMineral()
    {
        mineralList = new List<Mineral>();
        mineralPool = new List<Mineral>();

        GameObject mineralPrefab = Resources.Load("Mineral") as GameObject;

        GameObject mineralParent = new GameObject("MineralParent");
        mineralParent.transform.SetParent(this.transform);

        for (int i = 0; i < 30; i++)
        {
            Mineral m = ((GameObject)Instantiate(mineralPrefab)).GetComponent<Mineral>();
            m.Init(i);
            m.OnMineralHit += M_OnMineralHit;

            m.transform.SetParent(mineralParent.transform);
            mineralPool.Add(m);
        }
    }
    private void InitIndicator()
    {
        indicatorPool = new List<MineralIndicator>();
        indicatorList = new List<MineralIndicator>();


        GameObject indicatorPrefab = Resources.Load("MineralIndicator") as GameObject;

        GameObject indicatorParent = new GameObject("MineralIndicatorParent");
        indicatorParent.transform.SetParent(this.transform);

        for(int i = 0; i < 30;i++)
        {
            MineralIndicator mi = ((GameObject)Instantiate(indicatorPrefab)).GetComponent<MineralIndicator>();

            mi.Init(i);

            mi.transform.SetParent(indicatorParent.transform);
            indicatorPool.Add(mi);
        }

    }

    private void M_OnMineralHit(object sender, EventArgs e)
    {
        OnMineralHit(sender, e);
    }
}
