using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMove

{
    [SerializeField] float speed;
    public void Move(Vector2 deltaMove)
    {
        transform.position += speed * Time.deltaTime * Mathf.Sign(deltaMove.x) * transform.right;
    }

}
