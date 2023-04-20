using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    // Event
    public Action OnInteractionEvent;
    public Action<Vector3> OnMoveEvnet;
    public Action<Vector3> OnDashEvent;
    public Action<Vector3> OnRollingEvent;
    
    [Header("키 설정")]
    public KeyCode _interactionKey;

    [Space(10), Header("이동")]
    public KeyCode _upKey;
    public KeyCode _downKey;
    public KeyCode _leftKey;
    public KeyCode _rightKey;

    [Space(10), Header("대쉬와 구르기")]
    public KeyCode _dashKey;
    public KeyCode _rollingKey;

    private void Update()
    {
        OnInteraction();
        OnMove();
        OnDash();
        OnRolling();
    }

    private void OnInteraction()
    {
        if (Input.GetKeyDown(_interactionKey)) 
        {
            OnInteractionEvent?.Invoke();
        }
    }

    private void OnMove()
    {
        Vector3 dir = Vector3.zero;

        if (Input.GetKey(_upKey))
        {
            OnMoveEvnet?.Invoke(dir);
        }
    }

    private void OnDash()
    {
        if (Input.GetKeyDown(_dashKey))
        {
            OnDashEvent?.Invoke(new Vector3(0,0,0));
        }
    }

    private void OnRolling()
    {
        if (Input.GetKeyDown(_rollingKey))
        {
            OnRollingEvent?.Invoke(new Vector3(0,0,0));
        }
    }
    
}
