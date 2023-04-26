using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
    }

    public void ChangeCharacter(GameObject changeCharacter, bool condition)
    {
        if (condition)
        {
            _player = changeCharacter.gameObject;
        }
    }
}
