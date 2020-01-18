using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralIndicator : MonoBehaviour
{
    public int id;
    public void Init(int _id)
    {
        this.id = _id;
        Hide();
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Show(Vector3 randPos)
    {
        this.transform.position = randPos;

        this.gameObject.SetActive(true);
    }
}
