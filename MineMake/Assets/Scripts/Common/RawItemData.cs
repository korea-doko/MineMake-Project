using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable][CreateAssetMenu(fileName = "RawItem",menuName = "RawItem")]
public class RawItemData : ScriptableObject
{
    public string itemName;
    public int power;
    public int cost;
}
