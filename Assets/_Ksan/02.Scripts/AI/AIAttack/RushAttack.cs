using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushAttack : EnemyAttack
{

    [SerializeField]
    [Range(0, 20)]
    private float rushForce = 0;

    public override void Attack()
    {
        _brain.Move(Vector3.zero, false);

        Debug.Log("RushAttack");
        //일단 돌진만 구현해둠
        Vector2 dir = _brain.target.transform.position - transform.position;
        dir.Normalize();

        Debug.Log(dir);
        _brain.rigid.AddForce(dir * rushForce, ForceMode2D.Impulse);
    }
}
