using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    [SerializeField] private float _radius = 0f; // ¹ÝÁö¸§
    [SerializeField] private LayerMask _getLayer;

    private InputManager _inputManager;
    private Collider[] _cols = null;
    private List<IInteraction> _getObj;

    IInteraction obj = null;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        CheckRange();
        print(obj);
    }

    private void CheckRange()
    {
        _cols = Physics.OverlapSphere(transform.position, _radius, _getLayer);
        
        float closeDis = 100f;

        foreach(Collider a in _cols){
            float dis = Vector3.Distance(a.transform.position, transform.position);
            if (dis < closeDis)
            {
                closeDis = dis;
                obj = a.gameObject.GetComponent<IInteraction>();
            }

        }

        if (_cols.Length < 1)
        {
            obj = null;
            if (_inputManager.OnInteractionEvent != null)
                _inputManager.OnInteractionEvent = null;
        }
        else
        {
            obj.View();
            _inputManager.OnInteractionEvent = obj.Interaction;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
