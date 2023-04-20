using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAIState : CommonAIState
{
    public override void OnEnterState()
    {
        meshRenderer.material.color = Color.blue;
    }

    public override void OnExitState()
    {
    }
    public override void UpdateState()
    {
        base.UpdateState();
        enemyConroller.SetDestination(transform.position);
    }

}
