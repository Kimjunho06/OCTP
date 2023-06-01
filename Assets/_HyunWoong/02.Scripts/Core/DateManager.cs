using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateManager : MonoSingleton<DateManager>
{
    private static int _date;
    public static int date{
        get => _date;
        set => _date = value;
    }

    public void AddDate(){
        date++;
    }
}
