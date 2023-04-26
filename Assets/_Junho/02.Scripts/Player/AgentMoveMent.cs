using UnityEngine;

public class AgentMoveMent : MonoBehaviour
{
    public float _moveSpeed;

    public float _jumpPower;
    public int _jumpMaxCount;


    private int _jumpCount;

    private AgentInput _agentInput;
    private Rigidbody _playerRb;
    private Transform _camTrm;

    private LayerMask _groundLayer;

    private void Awake()
    {
        _agentInput = GetComponent<AgentInput>();
        _playerRb = GetComponent<Rigidbody>();
        _camTrm = Camera.main.transform;

        _groundLayer = LayerMask.GetMask("Ground");
    }

    private void Start()
    {
        _agentInput.OnMoveEvent += OnMove;
        _agentInput.OnJumpEvent += OnJump;

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
        transform.rotation = Quaternion.Euler(Vector3.up * _camTrm.eulerAngles.y);
    }

    private void GroundCheck()
    {
        if (_playerRb.velocity.y < 0)
        {
            if (_agentInput.RayCheck(transform.position, Vector3.down, 0.6f, _groundLayer))
            {
                _jumpCount = 1;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(transform.position, Vector3.down * 0.6f);
    }
}
