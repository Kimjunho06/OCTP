using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : AIAction
{
    private int crtIndex = 0;
    [SerializeField]
    private List<Vector3> points = new List<Vector3>();

    public override void TakeAction()
    {
        if (Vector3.Distance(points[crtIndex], transform.position) <= 0.5f)
        {
            crtIndex = (crtIndex+1)%points.Count;
            _brain.Move(true, points[crtIndex]);
        }
        else if(_brain.Agent.destination != points[crtIndex])
        {
            _brain.Move(true, points[crtIndex]);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeObject == gameObject)
        {
            Color oldColor = Color.white;
            Gizmos.color = Color.green;
            foreach(Vector3 pos in points)
                Gizmos.DrawSphere(pos, 0.5f);
            Gizmos.color = oldColor;
        }
    }
#endif
}
