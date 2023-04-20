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
        _inputManager.OnDashEvent += OnDash;
        _inputManager.OnRollingEvent += OnRolling;
        _inputManager.OnMoveEvnet += OnMove;
    }

    private void OnMove(Vector3 dir)
    {
        transform.position += dir * _moveSpeed * Time.deltaTime;
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
