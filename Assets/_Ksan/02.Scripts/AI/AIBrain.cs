using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class AIBrain : MonoBehaviour
{
    [SerializeField] private AIState _currentState;
    private AIStateInfo _stateInfo;

    public Transform target = null;
    public Rigidbody2D rigid = null;
    //공격 스크립트 넣어두는 리스트 만들어둬야 함
    public EnemyAttack[] _attackActions = { };

    private void Awake() {
        _stateInfo = transform.Find("AI").GetComponent<AIStateInfo>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        MakeAttackType();
    }

    private void MakeAttackType(){
        // 공격 스크립트 작성해야 함

        Transform atkTrm = transform.Find("AttackType");
        _attackActions = atkTrm.GetComponentsInChildren<EnemyAttack>();
    }

    public void ChangeToState(AIState nextState){
        _currentState = nextState;
    }

    protected virtual void Update() {
        _currentState.UpdateState();

        //StateInfo에 쿨들을 샐성해두고 쿨 관리해야함
        SkillCollDown();
    }

    private void SkillCollDown()
    {
        for(int i = 0; i < _attackActions.Length; i++)
        {
            _attackActions[i].CoolDown();
        }
    }

    public void Move(Vector2 direction, bool useMove)
    {
        
    }
}
