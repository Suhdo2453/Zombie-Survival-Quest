using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolObjectInParent : MonoBehaviour
{
    private BackPool _pool;

    private void Start()
    {
        _pool = GetComponentInParent<BackPool>();
    }

    public void BackPoolTrigger()
    {
        _pool.BackPoolObject();
    }
}