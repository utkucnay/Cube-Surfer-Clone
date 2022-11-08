using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMove

{
    [SerializeField] float _sideSpeed;
    [SerializeField] float _forwardSpeed;
    public void Move(Vector2 deltaMove)
    {
        var pos = transform.position;
        pos += _sideSpeed * Time.deltaTime * deltaMove.x * Vector3.right;
        pos.x = Mathf.Clamp(pos.x, -1.3f, 1.3f);
        transform.position = pos;
    }
    private void Update()
    {
        transform.position += _forwardSpeed * Time.deltaTime * Vector3.forward;
    }
}
