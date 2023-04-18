using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler current;
    public GameObject poolObject;
    public int pooledAmount;
    public bool willGrow;

    private List<GameObject> pooledObjects;

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(poolObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (var t in pooledObjects)
        {
            if (!t.activeInHierarchy)
            {
                return t;
            }
        }

        if (willGrow)
        {
            GameObject obj = Instantiate(poolObject);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }
}