using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    bool pressed = false;
    float pressedTime = 0;

    public void OnUpdate()
    {
        //if (EventSystem.current.IsPointerOverGameObject())
        //    return;

        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        if (MouseAction != null)
        {
            MouseAction.Invoke(Define.MouseEvent.Hover);

            if (Input.GetMouseButton(0))
            {
                if (!pressed)
                {
                    MouseAction.Invoke(Define.MouseEvent.Down);
                    pressedTime = Time.time;
                }
                else if (Time.time < pressedTime + 3.0f)
                {
                    MouseAction.Invoke(Define.MouseEvent.Hold);
                }
                MouseAction.Invoke(Define.MouseEvent.Press);
                pressed = true;
            }
            else
            {
                if (pressed)
                {
                    if (Time.time < pressedTime + 0.2f)
                        MouseAction.Invoke(Define.MouseEvent.Click);
                    MouseAction.Invoke(Define.MouseEvent.Up);
                }
                pressed = false;
                pressedTime = 0;
            }
        }
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}
