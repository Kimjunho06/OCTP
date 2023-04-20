using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    public bool IsReverse;

    protected AIActionData aiActionData;
    protected EnemyController enemyConroller;

    public virtual void SetUp(Transform enemyRoot){
        enemyConroller = enemyRoot.GetComponent<EnemyController>();
        aiActionData = enemyRoot.Find("AI").GetComponent<AIActionData>();
    }

    public abstract bool MakeADecision();
}
