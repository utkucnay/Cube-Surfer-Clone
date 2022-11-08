using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectObject : IEventWithParam
{
    public void CollectCube(ObjectType objectType);
}
