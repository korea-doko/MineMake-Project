using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum EMineralType
{
    M1,
    M2
}

[System.Serializable]
public class MineralData 
{
    public event EventHandler OnMineralLifeBelowZero;

    public static readonly int NumberOfMineralType = System.Enum.GetNames(typeof(EMineralType)).Length;

    public int id;
    public EMineralType mineralType;
    public int life;

    public MineralData(int _id)
    {
        this.id = _id;
    }

    public void GetDamaged(int _damage)
    {
        life = life - _damage;

        if (life <= 0)
        {

            OnMineralLifeBelowZero(this, EventArgs.Empty);
            
        }
    }
}
