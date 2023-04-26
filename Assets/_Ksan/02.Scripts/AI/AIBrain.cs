using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class AIBrain : MonoBehaviour, IDamageable
{
    [SerializeField] private AIState _currentState;
    private AIStateInfo _stateInfo;

    public GameObject Player { get; private set; }
    public NavMeshAgent Agent { get; private set; }

    public Rigidbody rigid = null;
    //공격 스크립트 넣어두는 리스트 만들어둬야 함
    public EnemyAttack[] _attackActions = { };

    public bool IsDamaged { get; private set; } = false;

    private void Awake() {
        Player = GameObject.FindGameObjectWithTag("Player");
        _stateInfo = transform.Find("AI").GetComponent<AIStateInfo>();
        Agent = GetComponent<NavMeshAgent>();
        Debug.Log(Agent);
        rigid = GetComponent<Rigidbody>();
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
        if(Input.GetKeyUp(KeyCode.Space))
            IsDamaged = true;
        //StateInfo에 쿨들을 샐성해두고 쿨 관리해야함
        SkillCollDown();
    }

    private void SkillCollDown()
    {
        for(int i = 0; i < _attackActions.Length; i++)
            _attackActions[i].CoolDown();
    }

    public void Move(bool useMove, Vector3 pos)
    {
        if(useMove)
        {
            Agent.isStopped = false;
            Agent.destination = pos;
        }
        else
        {
            Agent.isStopped = true;
        }
    }

    public void OnDamage(float damage)
    {
        IsDamaged = true;
    }

    public void IsOffDamaged() => IsDamaged = false;
}
