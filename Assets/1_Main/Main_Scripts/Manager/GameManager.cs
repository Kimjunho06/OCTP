using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject _player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } 

        _player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    private void Start()
    {
        Cursor.visible = false;
    }
}
