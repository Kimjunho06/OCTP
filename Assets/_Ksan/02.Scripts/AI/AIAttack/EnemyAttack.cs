using System;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _skillCoolTime = 0;
    private float _crtSkillCool = 0;
    [SerializeField]
    private float _delayCoolTime = 0;
    private float _crtDelayCool = 0;
    public bool IsCanUseSkill => (_crtSkillCool <= 0);
    public bool IsDelay => (_crtDelayCool > 0); // 딜레이 상태인가

    protected AIBrain _brain;
    protected virtual void Awake(){
        _brain = transform.parent.parent.GetComponent<AIBrain>();
    }
    public abstract void Attack();

    // coolDowning
    public void CoolDown()
    {
        if (_crtSkillCool > 0)
            _crtSkillCool -= Time.deltaTime;

        if (_crtDelayCool > 0)
            _crtDelayCool -= Time.deltaTime;
    }

    // crtCool = skillCoolTime
    public void SetAttackCool()
    {
        _crtSkillCool = _skillCoolTime;
        _crtDelayCool = _delayCoolTime;
    }
}
