using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private void OnEnable()
    {
        Invoke(nameof(Disable), 2f);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
