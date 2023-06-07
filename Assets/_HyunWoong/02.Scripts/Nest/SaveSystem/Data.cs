using UnityEngine;
using System;
using System.Collections.Generic;

public class Data
{
    public int date;
    public List<bool> isOnSpaceshipParts;

    public Data()
    {
        for(int i = 0; i < isOnSpaceshipParts.Count; ++i){
            isOnSpaceshipParts[i] = false;
        }
    }
};