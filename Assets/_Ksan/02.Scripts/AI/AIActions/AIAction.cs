using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    //공용으로 해줘야 할 일이 있어서 interface로 하지 않고 abstract

    //해당 상태에서 AI가 수행해야 할 액션
    //액션마다 할게 다르니까 추상 클래스로

    protected AIBrain _brain;

    private void Awake() {
        _brain = transform.parent.parent.GetComponent<AIBrain>();
    }

    public abstract void TakeAction(); //추상 메서드
}
