using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject _gameobject;
    public GameObject target;

    public void Spawn()
    {
        Instantiate(_gameobject, Vector3.zero, Quaternion.identity);
    }

    public void SpawnAtObject()
    {
        Instantiate(_gameobject, new Vector3(target.transform.position.x, target.transform.position.y, 0), Quaternion.identity);
    }
}