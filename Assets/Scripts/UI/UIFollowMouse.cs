using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollowMouse : MonoBehaviour
{
    public RectTransform MovingObject;
    public Vector2 offset;

    private void Update()
    {
       MoveObject();
    }
    public void MoveObject()
    {
        Vector2 pos = InputHandler.Instance.MousePosition + offset;
        MovingObject.position = pos;
    }
}
