using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private GameObject cursor;
    [SerializeField] private GameObject move;
    [SerializeField] private GameObject unit;

    private Vector2[,] map;
    private List<Vector2> inaccessible;

    private const float mapLeft = -10.0f;
    private const float mapRight = 2.0f;
    private const float mapTop = 5.625f;
    private const float mapBottom = -4.375f;

    private void Start()
    {
        GameManager.Input.MouseAction -= OnMouseEvent;
        GameManager.Input.MouseAction += OnMouseEvent;

        map = new Vector2[12, 10];
        float x = mapLeft;
        float y = mapBottom + 1.0f;

        for (int i = 0; i < 10; i++)
        {
            x = mapLeft;
            for (int j = 0; j < 12; j++)
            {
                map[j, i] = new Vector2(x, y);
                x += 1.0f;
            }
            y += 1.0f;
        }

        SetBattleScene();
    }

    private void SetBattleScene()
    {
        switch (GameManager.Data.Common.Battle)
        {
            case Define.Battle.GundamRising:
                GameObject amuroGundam = Instantiate(unit, transform, false);
                amuroGundam.GetComponent<SpriteRenderer>().sprite = GameManager.Resource.Load<Sprite>("Icons/RX-78-2");
                amuroGundam.transform.position = map[7, 3];
                inaccessible = new List<Vector2>() {
                    map[10, 2], map[10, 3], map[10, 4], map[10, 5], map[10, 6], map[10, 7],
                    map[11, 2], map[11, 3], map[11, 4], map[11, 5], map[11, 6], map[11, 7],
                    map[2, 4], map[3, 4], map[2, 5], map[3, 5], map[2, 2], map[2, 3]
                };
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
        if (GetPivotPosition(ref position))
        {
            Collider2D collider = GetColliderFromPosition(position);
            if (collider != null)
            {
                int speed = collider.GetComponent<UnitController>().Speed;
                DisplayMoveRange(position, speed);
            }
        }
    }

    private Collider2D GetColliderFromPosition(Vector2 position)
    {
        Ray2D ray = new(position + new Vector2(0.5f, -0.5f), Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        return hit.collider;
    }

    private void DisplayMoveRange(Vector2 position, int speed)
    {
        bool[,] block = new bool[speed * 2 + 1, speed * 2 + 1];

        for (int i = -speed; i <= speed; i++)
        {
            for (int j = -speed; j <= speed; j++)
            {
                if (Math.Abs(i) + Math.Abs(j) <= speed)
                {
                    Vector2 pos = new(position.x + i, position.y + j);
                    if (pos.y > mapTop - 2.0f || pos.y <= mapBottom + 2.0f)
                    {
                        block[i + speed, j + speed] = true;
                        continue;
                    }

                    if (inaccessible.Contains(pos))
                        continue;

                    Collider2D collider = GetColliderFromPosition(pos);
                    if (collider != null)
                        continue;

                    GameObject move = Instantiate(this.move, transform, false);
                    move.transform.position = pos;
                }
            }
        }

        bool[,] closed = new bool[speed * 2 + 1, speed * 2 + 1];
        int[,] open = new int[speed * 2 + 1, speed * 2 + 1];
        for (int i = -speed; i < speed + 1; i++)
            for (int j = -speed; j < speed + 1; j++)
                open[i, j] = int.MaxValue;
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