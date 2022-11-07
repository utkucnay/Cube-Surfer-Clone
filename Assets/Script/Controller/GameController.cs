using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : Singleton<GameController>
{
    UnityEvent e_StartGame;
    UnityEvent e_EndGame;

    private void Start()
    {
    }

    public override void Awake()
    {
        base.Awake();
        e_StartGame = new UnityEvent();
        e_EndGame = new UnityEvent();
        Observer.RegisterEventFromAllGameObjects<IStartGame>("StartGame", e_StartGame);
        Observer.RegisterEventFromAllGameObjects<IEndGame>("EndGame", e_EndGame);
    }
}
