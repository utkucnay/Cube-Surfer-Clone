using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMove

{
    [SerializeField] float speed;
    public void Move(float deltaMove)
    {
        transform.position += speed * Time.deltaTime * Mathf.Sign(deltaMove) * transform.right;
    }

}
