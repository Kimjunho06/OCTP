using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private CommonAIState currentState;

    private Transform targetTrm;
    public Transform TargetTrm=>targetTrm;

    public NavMeshAgent navAgent;

    private void Awake(){
        List<CommonAIState> states = new List<CommonAIState>();
        transform.Find("AI").GetComponentsInChildren<CommonAIState>(states);
        states.ForEach (s=>s.SetUp(transform));
        navAgent = GetComponent<NavMeshAgent>();
    }
    private void Start(){
        targetTrm = GameManager.Instance.PlayerTrm;
    }
    public void ChangeState(CommonAIState state){
        currentState?.OnExitState();
        currentState = state;
        currentState?.OnEnterState();
    }
    private void Update(){
        currentState?.UpdateState();
    }
    public void SetDestination(Vector3 pos){
        navAgent.SetDestination(pos);
    }
}
