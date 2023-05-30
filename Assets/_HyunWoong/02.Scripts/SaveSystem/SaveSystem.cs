using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data{
    public int index;
};

public class SaveSystem : MonoBehaviour
{
    public string filePath;
    public string fileName;

    Data data = new Data();

    [ContextMenu("세이브!")]
    public void Save(){
        if(!Directory.Exists(filePath)){
            Directory.CreateDirectory(filePath);

            if(!File.Exists(fileName)){
                    
            }
            else{
            }
        }
        else{

        }
    }
}
