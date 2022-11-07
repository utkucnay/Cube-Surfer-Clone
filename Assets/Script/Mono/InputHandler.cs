using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{

    float _oldXPos;

    UnityEvent<float> e_move;

    private void Awake()
    {
        e_move = new UnityEvent<float>();
        Observer.RegisterEventFromTransform<IMove, float>(transform, "Move", e_move);
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
                _oldXPos = touch.position.x; 
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                var deltaMove = touch.position.x - _oldXPos;
                _oldXPos = touch.position.x;
                e_move.Invoke(deltaMove);
            }
        }
           
               
        
    }
}
