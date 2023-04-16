using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Camera scenceCamera;
    public Vector2 RawMovementInput { get; private set; }
    public Vector2 MousePosition { get; private set; }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        //Debug.Log(RawMovementInput.normalized);
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
       Vector3 _MousePosition = context.ReadValue<Vector2>();
        MousePosition = scenceCamera.ScreenToWorldPoint(new Vector3(_MousePosition.x, _MousePosition.y, 0f));
    }
}
