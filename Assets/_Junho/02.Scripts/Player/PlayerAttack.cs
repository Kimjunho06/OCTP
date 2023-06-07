using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // private Animator _animator;

    private void Awake()
    {
        // _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
    }

    private void Attack()
    {
        /*
        
        if (gameObject.GetComponent<IDamage>() != null)
        {
            gameObject.GetComponent<IDamage>().OnDamage;
        }
        
        */
    }

    private void AttackAnimation(string playAnim)
    {
        // _animator.SetTrigger(playAnim);       
        print(playAnim + " 애니메이션 실행");
    }

    
}
