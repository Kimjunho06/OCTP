using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : CommonAIState
{
    public override void OnEnterState()
    {
        meshRenderer.material.color = Color.red;
    }

    public override void OnExitState()
    {

    }
    public override void UpdateState()
    {
        base.UpdateState();
        enemyConroller.SetDestination(transform.position);
        Debug.Log("예티 떄린다!");
    }
}
