using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    //조건들을 정의
    
    public List<AIDecision> decisions; //결정 사항들을 list로

    public AIState positiveResult; //모든 decision이 true라면 갈 곳
    public AIState negativeResult; //decision 중 하나라도 true 가 아니라면 갈 곳
}
