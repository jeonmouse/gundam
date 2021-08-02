using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension
{
    public static void BindEvent(this GameObject gameObject, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UIBase.BindEvent(gameObject, action, type);
    }
}
