using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public int X { get; set; }
    public int Y { get; set; }


    private void Start()
    {
        GameManager.Input.MouseAction -= OnMouseEvent;
        GameManager.Input.MouseAction += OnMouseEvent;
    }

    private void OnMouseEvent(Define.MouseEvent evt)
    {
        switch (evt)
        {
            case Define.MouseEvent.Click:
                break;
            case Define.MouseEvent.Hold:
                break;
        }
    }
}