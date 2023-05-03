using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public enum STATE { 
    DEFAULT,
    BIG,
    Slim,
}

public class EventManager : MonoBehaviour
{
    static public EventManager Instance;

    public List<CharacterData> _formList;

    private STATE _state;
    // private MeshFilter _playerForm;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        // _playerForm = GameManager.Instance._player.GetComponent<MeshFilter>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeCharacter(GameManager.Instance._player.GetComponent<MeshFilter>(), STATE.BIG);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            ChangeCharacter(GameManager.Instance._player.GetComponent<MeshFilter>(), STATE.Slim);
        }
    }

    public void ChangeCharacter(MeshFilter changeCharacterForm, STATE state)
    {
        if (/* _playerForm.mesh != changeCharacterForm &&*/ _state != state)
        {
            ClearForm(); 
            // _playerForm.mesh = changeCharacterForm.mesh;
            _state = state;

            ChangeForm(state);
        }
    }

    private void ChangeForm(STATE state)
    {
        switch (state) {
            case STATE.DEFAULT:
                break;
            case STATE.BIG:
                if (GameManager.Instance._player.GetComponent<CharacterBigForm>() == null)
                {
                    GameManager.Instance._player.AddComponent<CharacterBigForm>();
                    _formList.Add(GameManager.Instance._player.GetComponent<CharacterBigForm>());
                }

                GameManager.Instance._player.GetComponent<CharacterBigForm>().enabled = true;
                GameManager.Instance._player.GetComponent<CharacterBigForm>().Init();
                break;
            case STATE.Slim:
                if (GameManager.Instance._player.GetComponent<CharacterSlimForm>() == null)
                {
                    GameManager.Instance._player.AddComponent<CharacterSlimForm>();
                    _formList.Add(GameManager.Instance._player.GetComponent<CharacterSlimForm>());
                }

                GameManager.Instance._player.GetComponent<CharacterSlimForm>().enabled = true;
                GameManager.Instance._player.GetComponent<CharacterSlimForm>().Init();
                break;
        }
    }

    private void ClearForm()
    {
        foreach (var list in _formList)
        {
            list.enabled = false;
        }
    }
}
