using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    [SerializeField] private float _radius = 0f; // ������
    [SerializeField] private LayerMask _getLayer;

    private PlayerInput _agentInput;
    private Collider[] _cols = null;

    IInteractable obj = null;

    private void Awake()
    {
        _agentInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        CheckRange();
    }

    private void CheckRange()
    {
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
            print("You can Play InteractEvent!!");
            _agentInput.OnInteractionEvent = obj.Interact; // 쓰레기통이나 그런 곳 아이템 수집전 게이지 바 차는거 그쪽 스크립트에서 해야함, 적 데미지 주는 것 또한 저쪽 스크립트에서 해야함
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
