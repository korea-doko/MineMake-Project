using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPassManager : MonoBehaviour
{    
    private static DataPassManager inst;
    public static DataPassManager Inst { get => inst; }
    public DataPassManager() { inst = this; }


    public MineData chosenMineData;



    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
