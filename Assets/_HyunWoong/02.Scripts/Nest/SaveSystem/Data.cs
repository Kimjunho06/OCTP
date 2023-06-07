using UnityEngine;
using System;
using System.Collections.Generic;

public class Data
{
    public int date;
    public bool[] list = new bool[20];

    public Data()
    {
        date = 0;
        for(int i = 0; i < list.Length; ++i){
            list[i] = false;
        }
    }
};