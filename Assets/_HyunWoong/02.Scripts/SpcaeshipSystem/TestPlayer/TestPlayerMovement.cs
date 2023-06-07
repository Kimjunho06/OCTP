using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]private float _speed;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 moveDir  = new Vector3(h, 0, v).normalized;

        rb.AddForce(moveDir * _speed,ForceMode.Impulse);
    }
}
