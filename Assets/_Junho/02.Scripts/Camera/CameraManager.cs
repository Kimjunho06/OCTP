using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Á¶Á¤ °ª")]
    [SerializeField] float _awayX = -4f;
    [SerializeField] float _awayY = 7f;
    [SerializeField] float _awayZ = -4f;

    Camera _mainCam;
    Transform _player;

    private void Awake()
    {
        _mainCam = Camera.main;
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        _mainCam.transform.position
            = new Vector3(_player.transform.position.x + _awayX, _player.transform.position.y + _awayY, _player.transform.position.z + _awayZ);             
    }
}
