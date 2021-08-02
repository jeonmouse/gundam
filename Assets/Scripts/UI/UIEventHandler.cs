using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventHandler : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public Action<PointerEventData> ClickAction = null;
    public Action<PointerEventData> HoverAction = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ClickAction != null)
            ClickAction.Invoke(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (HoverAction != null)
            HoverAction.Invoke(eventData);
    }
}
