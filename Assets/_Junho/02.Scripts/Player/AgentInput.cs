using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentInput : MonoBehaviour
{
    public event Action<Vector3> OnMoveEvent;

    [Header("¡∂¿€≈∞")]
    [SerializeField] private KeyCode _upKey;
    [SerializeField] private KeyCode _downKey;
    [SerializeField] private KeyCode _leftKey;
    [SerializeField] private KeyCode _rightKey;

    private void FixedUpdate()
    {
        OnMove();
    }

    private void OnMove()
    {
        float hor = 0, ver = 0;

        if (Input.GetKey(_upKey)){
            ver = 1;
        }
        if (Input.GetKey(_downKey))
        {
            ver = -1;
        }
        if (Input.GetKey(_leftKey))
        {
            hor = -1;
        }
        if (Input.GetKey(_rightKey))
        {
            hor = 1;
        }
        
        Vector3 dir = new Vector3(hor, 0, ver);

        OnMoveEvent?.Invoke(dir);
    }
}
