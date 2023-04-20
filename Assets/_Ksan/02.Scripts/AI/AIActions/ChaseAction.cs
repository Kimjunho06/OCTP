using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAction
{
    private Vector3Int _beforeTargetPos = Vector3Int.zero;
    
    private Vector3 _nextPos;

    public override void TakeAction()
    {
        if(Vector3.Distance(_nextPos, transform.position) <= 0.2f)
        {
            SetNextPos();
        }

        _brain.Move((_nextPos - transform.position).normalized, true);
    }

    private void SetNextPos()
    {
    }
}
