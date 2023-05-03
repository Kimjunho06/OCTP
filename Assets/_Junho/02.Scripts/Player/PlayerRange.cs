﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRange : MonoBehaviour
{
    [SerializeField] private float _radius = 0f; // ������
    [SerializeField] private LayerMask _getLayer;

    private AgentInput _agentInput;
    private Collider[] _cols = null;

    IInteractable obj = null;

    private void Awake()
    {
        _agentInput = GetComponent<AgentInput>();
    }

    private void Update()
    {
        CheckRange();
    }

    private void CheckRange()
    {
        SceneManager.LoadScene("a", LoadSceneMode.Additive);

        _cols = Physics.OverlapSphere(transform.position, _radius, _getLayer);

        float closeDis = 1000;

        foreach (Collider a in _cols)
        {
            float dis = Vector3.Distance(a.transform.position, transform.position);
            if (dis < closeDis)
            {
                closeDis = dis;
                obj = a.gameObject.GetComponent<IInteractable>();
            }

        }

        if (_cols.Length < 1)
        {
            obj = null;
            if (_agentInput.OnInteractionEvent != null)
                _agentInput.OnInteractionEvent = null;
        }
        else
        {
            _agentInput.OnInteractionEvent = obj.Interaction;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}