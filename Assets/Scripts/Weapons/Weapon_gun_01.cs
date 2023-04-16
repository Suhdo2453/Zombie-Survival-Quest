using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon_gun_01 : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 aimDir;
    private float aimAngle;
    private Player player;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        player = GetComponentInParent<Player>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        mousePos = player.InputHandler.MousePosition;
        aimDir = mousePos - (Vector2)transform.position;
        aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimAngle));
        transform.rotation = rotation;
        FacingToMouse();
    }

    public void FacingToMouse()
    {
        if (player.FacingDirection == 1)
        {
            // Lật player sang trái
            _spriteRenderer.flipY = false;
        }
        else if (player.FacingDirection == -1)
        {
            // Lật player sang phải
            _spriteRenderer.flipY = true;
        }
    }

    private void Flip()
    {
        Debug.Log("flip weapon");
        transform.Rotate(0.0f, 180f, 0.0f);
    }
}