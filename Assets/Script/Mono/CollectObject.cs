using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectObject : MonoBehaviour
{
    [SerializeField] ObjectType _objectType;

    UnityEvent<ObjectType> e_collectObject;

    private void Start()
    {
        e_collectObject = new UnityEvent<ObjectType>();
        Observer.RegisterEventFromAllGameObjects<ICollectObject, ObjectType>("CollectCube", e_collectObject);
    }

    public void Collect(ObjectType objectType)
    {
        e_collectObject.Invoke(objectType);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collect(_objectType);
            this.gameObject.SetActive(false);
        }
    }
}
