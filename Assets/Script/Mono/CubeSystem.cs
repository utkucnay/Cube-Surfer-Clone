using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class CubeSystem : Singleton<CubeSystem> , ICollectObject
{
    List<GameObject> _cubes;
    List<GameObject> _tempObjects;
    float _baseLenght;

    [HideInInspector] public UnityEvent<ObjectType> e_collectCube;

    public override void Awake()
    {
        base.Awake();
        e_collectCube = new UnityEvent<ObjectType>();
        e_collectCube.AddListener(CollectCube);
        _cubes = new List<GameObject>();
        _tempObjects = new List<GameObject>();
    }

    private void Start()
    {
        _baseLenght = transform.position.y;
        CollectCube(ObjectType.DynamicCube);
    }

    private void LateUpdate()
    {
        _cubes.ForEach(go =>
        {
            if (!_tempObjects.Contains(go))
            {
                go.transform.position = new Vector3(transform.position.x, go.transform.position.y,transform.position.z);
            }
        });
    }

    public void CollectCube(ObjectType objectType)
    {
        var go = ObjectPool.s_Instance.GetObject(objectType);
        go.SetActive(true);
        _cubes.Add(go);

        int index = 1;
        float lenght = _baseLenght + _cubes.Count * go.transform.localScale.y;

        var pos = transform.position;
        pos.y = lenght;
        transform.position = pos;

        _cubes.ForEach(go =>
        {
            if (!_tempObjects.Contains(go))
            {
                go.transform.position = transform.position - index * go.transform.localScale.y / 2 * Vector3.up;
            }

            lenght += go.transform.localScale.y;
            index += 2;
        });
    }


    public void ObstacleEnter(int index)
    {
        CloseGravity();
        LoseCube(index);
    }

    public void ObstacleExit()
    {
        OpenGravity();
        _tempObjects.ForEach(go =>
        {
            _cubes.Remove(go);
            ObjectPool.s_Instance.SetObject(ObjectType.DynamicCube, go);
        });
        _tempObjects.Clear();
    }

    void CloseGravity()
    {
        _cubes.ForEach(go =>
        {
            go.GetComponent<Rigidbody>().useGravity = false;
        });
    }
    void OpenGravity()
    {
        _cubes.ForEach(go =>
        {
            go.GetComponent<Rigidbody>().useGravity = true;
        });
    }

    void LoseCube(int index)
    {
        var obj = _cubes[_cubes.Count - index];
        _tempObjects.Add(obj);
    }
}
