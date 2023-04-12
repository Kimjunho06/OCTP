using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    // Event
    public Action OnInteractionEvent;
    public Action<Vector3> OnMoveEvent;
    
    [Header("Å° ¼³Á¤")]
    public KeyCode interactionKey;
    [Space(10)]
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    private void Update()
    {
        OnInteraction();
        OnMove();
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

    
}
