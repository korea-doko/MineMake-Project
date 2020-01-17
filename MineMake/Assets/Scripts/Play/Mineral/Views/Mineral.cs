using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Mineral : MonoBehaviour
{
    public event EventHandler OnMineralHit;

    public int id;
    public SpriteRenderer spr;

    public void Init(int _id)
    {
        id = _id;
        spr = this.GetComponent<SpriteRenderer>();
        Hide();
    }
    

    public void Show(Vector3 pos)
    {
        this.transform.position = pos;
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
   
    public void MineralHit()
    {
        OnMineralHit(this, EventArgs.Empty);
    }

    public void ChangeColor(Color _color)
    {
        spr.color = _color;
    }

}
