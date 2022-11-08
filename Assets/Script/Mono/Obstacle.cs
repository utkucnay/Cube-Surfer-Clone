using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int index;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Mathf.Abs(transform.position.y - other.transform.position.y) < 0.1f)
        {
            CubeSystem.s_Instance.ObstacleEnter(index);
            Debug.Log("Cagrýldý");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CubeSystem.s_Instance.ObstacleExit();
        }
    }
}
