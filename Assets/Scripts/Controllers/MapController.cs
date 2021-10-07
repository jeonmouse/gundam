using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private GameObject cursor;

    private void Start()
    {
        GameManager.Input.MouseAction -= OnMouseEvent;
        GameManager.Input.MouseAction += OnMouseEvent;

        cursor.SetActive(true);
    }

    private void OnMouseEvent(Define.MouseEvent evt)
    {
        switch (evt)
        {
            case Define.MouseEvent.Hover:
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                cursor.transform.position = new Vector2(Mathf.FloorToInt(mousePos.x), Mathf.FloorToInt(mousePos.y));
                break;
            case Define.MouseEvent.Click:
                break;
            case Define.MouseEvent.Hold:
                break;
        }
    }
}