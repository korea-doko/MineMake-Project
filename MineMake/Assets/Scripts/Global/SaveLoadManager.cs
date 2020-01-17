using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager : MonoBehaviour
{
    private static SaveLoadManager inst;    
    public static SaveLoadManager Inst { get => inst; }
    public SaveLoadManager() { inst = this; }


    [SerializeField] public PlayerResource playerResource;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        LoadPlayerResource();
    }
    

    public static void SavePlayerResource( PlayerResource _pr)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerResource.dk";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerResource data = new PlayerResource(_pr);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerResource LoadPlayerResource()
    {
        string path = Application.persistentDataPath + "/playerResource.dk";

        if( File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerResource data = formatter.Deserialize(stream) as PlayerResource;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("파일이 없음");
            return null;
        }
    }

    
}
