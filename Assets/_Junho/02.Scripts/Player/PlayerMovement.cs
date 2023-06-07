using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _moveSpeed;

    public float _jumpPower;
    public int _jumpMaxCount;

    public float _groundRayDistance;

    private int _jumpCount;

    private PlayerInput _playerInput;
    private Rigidbody _playerRb;
    private Transform _camTrm;

    private LayerMask _groundLayer;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerRb = GetComponent<Rigidbody>();
        _camTrm = Camera.main.transform;

        _groundLayer = LayerMask.GetMask("Ground");
    }

    private void Start()
    {
        _playerInput.OnMoveEvent += OnMove;
        _playerInput.OnJumpEvent += OnJump;

        _jumpCount = 1;
    }

    private void Update()
    {
        GroundCheck();
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

    private void OnJump(Vector3 dir)
    {

        if (_jumpCount <= _jumpMaxCount)
        {
            //_playerRb.AddForce(dir * _jumpPower, ForceMode.Impulse);
            dir.x = _playerRb.velocity.x;
            dir.z = _playerRb.velocity.z;
            _playerRb.velocity = dir * _jumpPower;

            _jumpCount++;
        }
    }

    private void OnRotate()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            return;
        }

        transform.rotation = Quaternion.Euler(Vector3.up * _camTrm.eulerAngles.y);
    }

    private void GroundCheck()
    {
        if (_playerRb.velocity.y < 0)
        {
            if (_playerInput.RayCheck(transform.position, Vector3.down, _groundRayDistance, _groundLayer))
            {
                _jumpCount = 1;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(transform.position, Vector3.down * _groundRayDistance);
    }
}
