using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 
public class InnerDistanceDecision : AIDecision
{
    [SerializeField]
    private float radius = 5f;
    [SerializeField]
    private float angleRange = 40f;
    [SerializeField]
    bool alwayLook = false;


    public override bool MakeADecision()
    {
        if(enemyConroller.TargetTrm == null)return false;
        Vector3 vector = enemyConroller.TargetTrm.position - transform.position;

        if (vector.magnitude <= radius)
        {
         float dot = Vector3.Dot(vector.normalized, transform.forward);
            // 두 벡터 모두 단위 벡터이므로 내적 결과에 cos의 역을 취해서 theta를 구함
            float theta = Mathf.Acos(dot);
            // angleRange와 비교하기 위해 degree로 변환
            float degree = Mathf.Rad2Deg * theta;
            // 시야각 판별
            if (degree <= angleRange / 2f)
                aiActionData.TargetSpotted = true;
            else
                aiActionData.TargetSpotted = false;  
        }
        else aiActionData.TargetSpotted = false;
        return aiActionData.TargetSpotted;
    }

    private void OnDrawGizmos() {
        if(UnityEditor.Selection.activeObject == gameObject||alwayLook){
            Handles.color = aiActionData.TargetSpotted ? Color.red : Color.blue;
            // DrawSolidArc(시작점, 노멀벡터(법선벡터), 그려줄 방향 벡터, 각도, 반지름)
            Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, angleRange / 2, radius);
            Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -angleRange / 2, radius);
        }
    }
}