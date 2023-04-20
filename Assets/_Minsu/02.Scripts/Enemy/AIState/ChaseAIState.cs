using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAIState : CommonAIState
{
    public override void OnEnterState()
    {
        meshRenderer.material.color = Color.green;
    }

    public override void OnExitState()
    {

    }
    public override void UpdateState()
    {
        base.UpdateState();
        enemyConroller.SetDestination(enemyConroller.TargetTrm.position);
    }
}
