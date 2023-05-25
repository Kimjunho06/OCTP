using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackState
{
    BITE,
    SCRATCH
}

public class PlayerAttack : MonoBehaviour
{
    AttackState state;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RandomAttack();
            AttackAnimation(state);
        }
    }

    private void RandomAttack()
    {
        int random = Random.Range(0, 2);

        switch (random)
        {
            case 0:
                state = AttackState.BITE;
                Attack(state, 2);
                break;
            case 1:
                state = AttackState.SCRATCH;
                Attack(state, 4);
                break;
        }
    }

    private void AttackAnimation(AttackState state)
    {

    }

    private void Attack(AttackState state, float range)
    {

    }
}
