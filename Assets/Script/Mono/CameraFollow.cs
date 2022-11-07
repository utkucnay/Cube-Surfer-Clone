using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        float playerZ = _player.transform.position.z;
        transform.position = playerZ * Vector3.forward;
    }
}
