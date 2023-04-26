using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentInput : MonoBehaviour
{
    public Action OnInteractionEvent;
    public event Action<Vector3> OnMoveEvent;
    public event Action<Vector3> OnJumpEvent;

    [Header("¡∂¿€≈∞")]
    [SerializeField] private KeyCode _upKey;
    [SerializeField] private KeyCode _downKey;
    [SerializeField] private KeyCode _leftKey;
    [SerializeField] private KeyCode _rightKey;
    
    [SerializeField] private KeyCode _jumpKey;
    [SerializeField] private KeyCode _interactionKey;

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
        if (Input.GetKeyDown(_jumpKey))
        {
            OnJumpEvent?.Invoke(Vector3.up);
        }
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

    private void OnInteraction()
    {
        if (Input.GetKeyDown(_interactionKey))
        {
            OnInteractionEvent?.Invoke();
        }
    }

    public bool RayCheck(Vector3 pos, Vector3 dir, float distance, LayerMask layerMask)
    {
        RaycastHit raycastHit;
        

        if (Physics.Raycast(pos, dir, out raycastHit, distance, layerMask))
        {
            if (raycastHit.collider != null){
                return true;
            }
        }

        return false;
    }


}
