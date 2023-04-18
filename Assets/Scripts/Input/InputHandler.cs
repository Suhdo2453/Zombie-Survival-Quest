using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Camera scenceCamera;
    public Vector2 RawMovementInput { get; private set; }
    public Vector2 MousePosition { get; private set; }
    public Boolean AttackInput { get; private set; }

    private void Update()
    {
        MousePosition = scenceCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInput = true;
        }

        if (context.canceled)
        {
            AttackInput = false;
        }
    }
}
