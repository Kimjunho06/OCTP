using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    // Event
    public Action OnInteractionEvent;
    public Action<Vector3> OnMoveEvent;
    public Action<Vector3> OnRotateEvent;
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
        OnMove();
        OnRotate();
        OnInteraction();
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
        if (Input.GetKey(_upKey))
        {
            OnMoveEvent?.Invoke(transform.forward);
        }
     
        if (Input.GetKey(_downKey))
        {
            OnMoveEvent?.Invoke(transform.forward * -1);
        }
    }

    private void OnRotate()
    {
        float hor = 0;

        if (Input.GetKey(_leftKey)) hor = -1;
        if (Input.GetKey(_rightKey)) hor = 1;

        OnRotateEvent?.Invoke(new Vector3(0, hor, 0));
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
