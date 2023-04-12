using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputManager _inputManager;

    [Range(0, 20)]
    public float moveSpeed;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
    }

    private void Start()
    {
        _inputManager.OnMoveEvent += OnMove;
    }

    private void OnMove(Vector3 pos)
    {
        Vector3 dir = Quaternion.Euler(0,45f,0) * pos;
        transform.position += dir * moveSpeed * Time.deltaTime;
        print(pos);
    }
}
