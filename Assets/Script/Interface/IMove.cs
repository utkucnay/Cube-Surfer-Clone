using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove :IEventWithParam
{
    public void Move(float deltaMove);
}
