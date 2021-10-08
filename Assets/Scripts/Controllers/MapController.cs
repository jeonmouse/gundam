using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private GameObject cursor;

    private const float mapLeft = -10.0f;
    private const float mapRight = 2.0f;
    private const float mapTop = 5.625f;
    private const float mapBottom = -4.375f;

    private void Start()
    {
        GameManager.Input.MouseAction -= OnMouseEvent;
        GameManager.Input.MouseAction += OnMouseEvent;
    }

    private void OnMouseEvent(Define.MouseEvent evt)
    {
        switch (evt)
        {
            case Define.MouseEvent.Hover:
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                DisplayCursor(mousePos);
                //cursor.transform.position = new Vector2(Mathf.FloorToInt(mousePos.x), Mathf.FloorToInt(mousePos.y));
                break;
            case Define.MouseEvent.Click:
                break;
            case Define.MouseEvent.Hold:
                break;
        }
    }

    private void DisplayCursor(Vector2 position)
    {
        if (GetPointOnMap(ref position))
        {
            if (cursor.activeSelf == false)
                cursor.SetActive(true);

            cursor.transform.position = position;
        }
        else
        {
            if (cursor.activeSelf == true)
                cursor.SetActive(false);
        }
    }

    private bool GetPointOnMap(ref Vector2 position)
    {
        if (position.x < mapLeft || position.x > mapRight || position.y > mapTop || position.y < mapBottom)
            return false;

        position.x = Mathf.Floor(position.x);
        position.y = mapTop - Mathf.Floor(mapTop - position.y);
        
        return true;
    }
}