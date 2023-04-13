using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class PlayerMovement : MonoBehaviour
{
    InputManager _inputManager;

    public float _moveSpeed;
    public float _rotateSpeed;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
    }

    private void Start()
    {
        _inputManager.OnMoveEvent += OnMove;
        _inputManager.OnDashEvent += OnDash;
        _inputManager.OnRollingEvent += OnRolling;
        _inputManager.OnRotateEvent += OnRotate;
    }

    private void OnMove(Vector3 dir)
    {
        transform.position += dir * Time.deltaTime * _moveSpeed;
    }

    private void OnRotate(Vector3 dir)
    {
        transform.eulerAngles += dir * _rotateSpeed * Time.deltaTime;   
    }

    private void OnDash(Vector3 dir)
    {
        print(dir + " 방향으로 대쉬");

    }

    private void OnRolling(Vector3 dir)
    {
        print(dir + " 방향으로 구르기");
        
    }

    IEnumerator CoolDown(float cool)
    {
        yield return new WaitForSeconds(cool);
    }

}
