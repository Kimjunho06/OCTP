using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBigForm : CharacterData
{
    AgentMoveMent _agentMoveMent;


    private void Awake()
    {
        _agentMoveMent = GameManager.Instance._player.GetComponent<AgentMoveMent>();
    }
    
    private void Update()
    {
        OtherPlayerSkill();
    }

    public override void Init()
    {
        EventManager.Instance.ChangeCharacter(_characterForm, STATE.BIG);       
        transform.localScale *= 2;
        _agentMoveMent._moveSpeed -= 2;
    }

    protected override void OtherPlayerSkill()
    {
    }
}
