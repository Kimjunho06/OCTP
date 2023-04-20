using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMoveMent : MonoBehaviour
{
    public float _moveSpeed;
    
    private AgentInput _agentInput;
    private Rigidbody _playerRb;

    private Transform _camTrm;

    private void Awake()
    {
        _agentInput = GetComponent<AgentInput>();
        _playerRb = GetComponent<Rigidbody>();
        _camTrm = FindObjectOfType<CinemachineFreeLook>().GetComponent<Transform>();
    }

    private void Start()
    {
        _agentInput.OnMoveEvent += OnMove;
    }

    private void FixedUpdate()
    {
        OnRotate();
    }

    private void OnMove(Vector3 dir)
    {
        dir *= _moveSpeed;
        dir = dir.z * transform.forward + dir.x * transform.right;
        dir.y = _playerRb.velocity.y;
       
        _playerRb.velocity = dir;   
    }

    private void OnRotate()
    {
        Vector3 dir = transform.position - _camTrm.position;
        float angle = Vector3.Angle(dir, _camTrm.transform.forward);

        transform.rotation = Quaternion.AngleAxis(angle, _camTrm.transform.up);
    }
}
