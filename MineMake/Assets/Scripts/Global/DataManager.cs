using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager inst;    
    public static DataManager Inst { get => inst;}
    public DataManager() { inst = this; }


    public List<RawItemData> itemDataList;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        LoadItemData();
    }

    private void LoadItemData()
    {
        itemDataList = new List<RawItemData>();

        RawItemData[] ids = Resources.LoadAll<RawItemData>("SOs/Item");


        foreach (RawItemData id in ids)
            itemDataList.Add(id);
    }
}
