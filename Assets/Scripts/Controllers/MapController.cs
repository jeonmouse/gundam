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
                inaccessible = new List<Vector2>() {
                    map[10, 2], map[10, 3], map[10, 4], map[10, 5], map[10, 6], map[10, 7],
                    map[11, 2], map[11, 3], map[11, 4], map[11, 5], map[11, 6], map[11, 7],
                    map[2, 4], map[3, 4], map[2, 5], map[3, 5], map[2, 2], map[2, 3]
                };

                GameManager.Data.Characters.Add(Define.Character.AmuroRay, new Character(
                    Define.Character.AmuroRay, Define.Affiliation.EFSF, Define.Rank.SeamanRecruit, 0, 0));

                GameObject amuroGundam = Instantiate(unit, transform, false);
                amuroGundam.GetComponent<UnitController>().InitUnit(Define.Character.AmuroRay, Define.Mechanic.Gundam2);
                amuroGundam.transform.position = map[7, 3];
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

    struct Node : IComparable<Node>
    {
        public int F;
        public int G;
        public int X;
        public int Y;

        public int CompareTo(Node other)
        {
            if (F == other.F)
                return 0;
            return F < other.F ? 1 : -1;
        }
    }

    private void DisplayMoveRange(Vector2 position, int speed)
    {
        int boardSize = speed * 2 + 1;
        bool[,] block = new bool[boardSize, boardSize];
        List<Vector2> accessible = new List<Vector2>();
        Vector2 startPoint = new Vector2(speed + 1, speed + 1); 

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
                    {
                        block[i + speed, j + speed] = true;
                        continue;
                    }

                    Collider2D collider = GetColliderFromPosition(pos);
                    if (collider != null && collider.gameObject.GetComponent<UnitController>().Pilot.Affiliation != Define.Affiliation.EFSF)
                    {
                        block[i + speed, j + speed] = true;
                        continue;
                    }

                    block[i + speed, j + speed] = false;
                    accessible.Add(new Vector2(i + speed, j + speed));

                    //------
                    GameObject move = Instantiate(this.move, transform, false);
                    move.transform.position = pos;
                    //------
                }
            }
        }

        bool[,] closed = new bool[boardSize, boardSize];
        int[,] open = new int[boardSize, boardSize];
        for (int i = 0; i < boardSize; i++)
            for (int j = 0; j < boardSize; j++)
                open[i, j] = int.MaxValue;

        Vector2[,] parent = new Vector2[boardSize, boardSize];

        Queue<Node> nodes = new Queue<Node>();

        foreach (Vector2 endPoint in accessible)
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