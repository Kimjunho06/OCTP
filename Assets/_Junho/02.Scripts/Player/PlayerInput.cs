using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Action OnInteractionEvent;
    public event Action<Vector3> OnMoveEvent;
    public event Action<Vector3> OnJumpEvent;

    private void Update()
    {
        OnJump();
        OnInteraction();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    private void OnJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpEvent?.Invoke(Vector3.up);
        }
    }

    private void OnMove()
    {
        float hor = 0, ver = 0;

        if (Input.GetKey(KeyCode.W))
        {
            ver = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            ver = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            hor = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            hor = 1;
        }

        Vector3 dir = new Vector3(hor, 0, ver);

        OnMoveEvent?.Invoke(dir);
    }

    private void OnInteraction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnInteractionEvent?.Invoke();
        }
    }

    public bool RayCheck(Vector3 pos, Vector3 dir, float distance, LayerMask layerMask)
    {
        RaycastHit raycastHit;


        if (Physics.Raycast(pos, dir, out raycastHit, distance, layerMask))
        {
            if (raycastHit.collider != null)
            {
                return true;
            }
        }

        return false;
    }
}
