using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGView : MonoBehaviour
{
    public List<BG> bgList;

    public float BGHeight;

    public void Init(BGModel model)
    {
        InitBGList();
    }
    

    private void InitBGList()
    {
        GameObject bgPrefab = Resources.Load("BG") as GameObject;

        SpriteRenderer sp = bgPrefab.GetComponent<SpriteRenderer>();
        float width = sp.sprite.bounds.size.x;
        float scaleX = bgPrefab.transform.localScale.x;

        BGHeight = width * scaleX;

        for(int i = 0; i < 3;i++)
        {
            BG bg = ((GameObject)Instantiate(bgPrefab)).GetComponent<BG>();
            bg.Init(i);

            bg.transform.position = new Vector3(0, -i * BGHeight, 0);

            bg.transform.SetParent(this.transform);
            bgList.Add(bg);
        }
    }

    
}
