using System;
using System.Collections;
using System.Collections.Generic;
using Ultilites;
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
        ObjectPooler.Instance.CoolObject(gameObject);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Entity>(out Entity entityComponent))
        {
            entityComponent.Damage(12f);
            Disable();
        }
    }
}