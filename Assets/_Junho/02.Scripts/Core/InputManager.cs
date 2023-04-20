using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    // Event
    public Action OnInteractionEvent;
    public Action<Vector3> OnMoveEvent;
    public Action<Vector3> OnDashEvent;
    public Action<Vector3> OnRollingEvent;
    
    [Header("키 설정")]
    public KeyCode interactionKey;

    [Space(10), Header("이동")]
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    [Space(10), Header("대쉬와 구르기")]
    public KeyCode dashKey;
    public KeyCode rollingKey;

    private void Update()
    {
        OnInteraction();
        OnMove();
        OnDash();
        OnRolling();
    }

    private void OnInteraction()
    {
        if (Input.GetKeyDown(interactionKey)) 
        {
            OnInteractionEvent?.Invoke();
        }
    }

    private void OnMove()
    {
        float hor = 0;
        float ver = 0;

        if (Input.GetKey(leftKey)) hor = -1;
        if (Input.GetKey(rightKey)) hor = 1;
        if (Input.GetKey(upKey)) ver = 1;
        if (Input.GetKey(downKey)) ver = -1;

        OnMoveEvent?.Invoke(new Vector3(hor, 0, ver));
    }

    private void OnDash()
    {
        if (Input.GetKeyDown(dashKey))
        {
            OnDashEvent?.Invoke(new Vector3(0,0,0));
        }
    }

    private void OnRolling()
    {
        if (Input.GetKeyDown(rollingKey))
        {
            OnRollingEvent?.Invoke(new Vector3(0,0,0));
        }
    }
    
}
