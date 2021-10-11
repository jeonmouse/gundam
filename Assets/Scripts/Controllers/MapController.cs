using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private GameObject cursor;
    [SerializeField] private GameObject move;
    [SerializeField] private GameObject testUnit;  // For TEST

    private const float mapLeft = -10.0f;
    private const float mapRight = 2.0f;
    private const float mapTop = 5.625f;
    private const float mapBottom = -4.375f;

    private void Start()
    {
        GameManager.Input.MouseAction -= OnMouseEvent;
        GameManager.Input.MouseAction += OnMouseEvent;

        // TEST
        testUnit.transform.position = new Vector2(-3.0f, -0.375f);

    }

    private void SetBattleScene()
    {
        switch (GameManager.Data.Common.Battle)
        {
            case Define.Battle.GundamRising:
                //msMap[7, 1] = (int)Define.Character.Amuro;
                break;
        }
    }

    private void OnMouseEvent(Define.MouseEvent evt)
    {
        switch (evt)
        {
            case Define.MouseEvent.Hover:
                DisplayCursor();
                break;
            case Define.MouseEvent.Click:
                ClickMap();
                break;
            case Define.MouseEvent.Hold:
                break;
        }
    }

    private void ClickMap()
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray2D ray = new(position, Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider != null)
        {
            
        }
    }

    private void DisplayCursor()
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (GetPivotPosition(ref position))
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

    private bool GetPivotPosition(ref Vector2 position)
    {
        if (position.x < mapLeft || position.x > mapRight || position.y > mapTop || position.y < mapBottom)
            return false;

        position.x = Mathf.Floor(position.x);
        position.y = mapTop - Mathf.Floor(mapTop - position.y);
        
        return true;
    }
}