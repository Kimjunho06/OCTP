using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : AIAction
{
    [SerializeField]
    private int _attackTypeIndex = 0;

    public override void TakeAction()
    {
        //

        if (_brain._attackActions[_attackTypeIndex].IsCanUseSkill)
        {
            EnemyAttack attackType = _brain._attackActions[_attackTypeIndex];
            if (attackType == null) return;
            attackType.SetAttackCool();
            attackType.Attack();
        }
        
    }
}
