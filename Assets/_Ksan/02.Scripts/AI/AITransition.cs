using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    //조건?�을 ?�의
    
    public List<AIDecision> decisions; //결정 ?�항?�을 list�?

    public AIState positiveResult; //모든 decision??true?�면 �?�?
    public AIState negativeResult; //decision �??�나?�도 true 가 ?�니?�면 �?�?
}
