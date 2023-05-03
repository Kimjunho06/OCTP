using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{   
    //내가 이 상태에서 수행해야할 액션들을 여기서 가지고 있는다.
    public List<AIAction> actions = null;
    //내가 이 상태에서 전이가 가능한 상태로의 전이 리스트
    public List<AITransition> transitions = null;

    private AIBrain _brain;

    private void Awake() {
        _brain = transform.parent.parent.GetComponent<AIBrain>();
        //_brain = GetComponentInParent<AIBrain>();
    }

    public void UpdateState(){
        //모든 상태는 매 프레임 마다 이 메서드를 실행
        foreach(AIAction a in actions){
            a.TakeAction();
        }

        foreach(AITransition t in transitions){
            bool result = false;

            foreach(AIDecision d in t.decisions){
                result = d.MakeADecision();
                if(!result) break;
            }

            //모든 decision을 만족하는 상태
            if(result){
                if(t.positiveResult != null){
                    _brain.ChangeToState(t.positiveResult);
                }
            }
            else{
                if(t.negativeResult != null){
                    _brain.ChangeToState(t.negativeResult);
                }
            }
        }
    }
}
