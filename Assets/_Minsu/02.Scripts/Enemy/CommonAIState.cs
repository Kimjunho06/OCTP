using System.Collections.Generic;
using UnityEngine;

public abstract class CommonAIState : MonoBehaviour,IState {

    [SerializeField]
    protected List<AITransition> transitions;
    protected EnemyController enemyConroller;
    protected AIActionData actionData;
    protected MeshRenderer meshRenderer = null;


    public abstract void OnEnterState();

    public abstract void OnExitState();


    public virtual void SetUp(Transform agentRoot)
    {
        enemyConroller = agentRoot.GetComponent<EnemyController>();
        actionData = agentRoot.Find("AI").GetComponent<AIActionData>();
        meshRenderer = agentRoot.Find("Cube").GetComponent<MeshRenderer>();

        transitions = new List<AITransition>();

        transform.GetComponentsInChildren<AITransition>(transitions);

        transitions.ForEach(d=>d.SetUp(agentRoot));
        
    }

    public virtual void UpdateState()
    {
        foreach(AITransition t in transitions){
            bool result = false;
            if(t.CheckTransition()){
                enemyConroller.ChangeState(t.NextState);
                break;
            }
        }
    }
}