using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class AIBrain : MonoBehaviour, IDamageable, IInteractable
{
    [SerializeField] private AIState _currentState;
    private AIStateInfo _stateInfo;

    public GameObject Player { get; private set; }
    public NavMeshAgent Agent { get; private set; }

    public Rigidbody rigid = null;
    //공격 스크립트 넣어두는 리스트 만들어둬야 함
    public EnemyAttack[] _attackActions = { };

    public bool IsBattled { get; private set; } = false;
    public HP hp { get; private set; }

    private void Awake() {
        Player = GameObject.FindGameObjectWithTag("Player");
        _stateInfo = transform.Find("AI").GetComponent<AIStateInfo>();
        hp = transform.Find("HP").GetComponent<HP>();
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
        IsBattled = true;
        hp.DamagedHealth(damage);

        if (hp.crtHP <= 0)
            DeathMob(); // 나중에 코드 수정 필요
    }

    private void DeathMob()
    {
        //임시
        Destroy(gameObject);
    }

    public void IsOffBattleState() => IsBattled = false;

    public void Interaction()
    {
        OnDamage(10);
    }
}
