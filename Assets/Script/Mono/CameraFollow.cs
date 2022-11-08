using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject _player;

    private void Awake()
    {

    }

    private void LateUpdate()
    {
        float playerZ = Mathf.Lerp(transform.position.z, _player.transform.position.z - 6, 1f);
        transform.position = new Vector3(transform.position.x, transform.position.y, playerZ);
    }
}
