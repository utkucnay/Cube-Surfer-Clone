using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{

    Vector2 _oldPos;

    UnityEvent<Vector2> e_move;

    private void Awake()
    {
        e_move = new UnityEvent<Vector2>();
        Observer.RegisterEventFromTransform<IMove, Vector2>(transform, "Move", e_move);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            return;
        

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _oldPos = touch.position; 
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                var deltaMove = touch.position - _oldPos;
                _oldPos = touch.position;
                var time = Time.realtimeSinceStartup;
                e_move.Invoke(deltaMove);
                Debug.Log((Time.realtimeSinceStartup - time) * 1000000);
            }
        }
           
               
        
    }
}
