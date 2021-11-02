using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private Vector2[,] map;
    private GameObject cursor;
    private List<Vector2> inaccessible;
    private Dictionary<Vector2, Vector2Int[,]> paths;
    private List<Vector2> enemyPosition;
    private GameObject selectedUnit = null;
    private List<UnitController> units = new();
    private UIBattle ui;
    private Vector2 prePos = new(0f, 0f);

    private const float mapLeft = -10.0f;
    private const float mapRight = 2.0f;
    private const float mapTop = 5.625f;
    private const float mapBottom = -4.375f;

    private enum Mode
    {
        Select = 0,
        Move = 1,
        Attack = 2
    }
    private Mode mode = Mode.Select;

    private void Start()
    {
        GameManager.Input.MouseAction += OnMouseEvent;
        ui = GameObject.Find("Canvas").GetComponent<UIBattle>();
        ui.StartBattle += StartBattle;

        cursor = GameManager.Resource.Instantiate("Prefab/Cursor", transform);
        
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

        InitScene();
    }

    private void InitScene()
    {
        GameManager.Data.Common.Scene = GameManager.Data.Common.NextScene;

        switch (GameManager.Data.Common.Scene)
        {
            case Define.Scene.GundamRising:
                inaccessible = new List<Vector2>() {
                    map[10, 2], map[10, 3], map[10, 4], map[10, 5], map[10, 6], map[10, 7],
                    map[11, 2], map[11, 3], map[11, 4], map[11, 5], map[11, 6], map[11, 7],
                    map[2, 4], map[3, 4], map[2, 5], map[3, 5], map[2, 2], map[2, 3]
                };

                GameManager.Data.Characters.Add(Define.Character.AmuroRayTutorial, new Character(
                    Define.Character.AmuroRayTutorial, Define.Affiliation.EFSF, Define.Rank.SeamanRecruit, 0, 0));

                CreateUnit(Define.Character.Denim, Define.Mechanic.Zaku2, Define.Affiliation.Zeon, Define.Rank.ChiefPettyOfficer, 2, 1, 6, 4);
                CreateUnit(Define.Character.Gene, Define.Mechanic.Zaku2, Define.Affiliation.Zeon, Define.Rank.PettyOfficer2ndClass, 1, 1, 7, 4);

                if (GameManager.Data.Common.MainCharacter == Define.Character.BrightNoa || GameManager.Data.Common.MainCharacter == Define.Character.RhysJeon)
                    CreateUnit(Define.Character.AmuroRayTutorial, Define.Mechanic.Gundam2, 7, 3);
                else
                    CreateUnit(GameManager.Data.Common.MainCharacter, Define.Mechanic.Gundam1, 3, 3);

                break;
        }
    }

    private void CreateUnit(Define.Character character, Define.Mechanic mechanic, int x, int y)
    {
        GameObject go = GameManager.Resource.Instantiate("Prefab/Unit", transform);
        go.name = character.ToString() + mechanic.ToString();
        go.transform.position = map[x, y];
        UnitController unit = go.GetComponent<UnitController>();
        unit.Init(character, mechanic);
        units.Add(unit);
    }
    
    private void CreateUnit(Define.Character character, Define.Mechanic mechanic, Define.Affiliation affiliation, Define.Rank rank,
        int pilotLevel, int captainLevel, int x, int y)
    {
        GameObject go = GameManager.Resource.Instantiate("Prefab/Unit", transform);
        go.name = character.ToString() + mechanic.ToString();
        go.transform.position = map[x, y];
        UnitController unit = go.GetComponent<UnitController>();
        unit.Init(character, mechanic, affiliation, rank, pilotLevel, captainLevel);
        units.Add(unit);
    }

    private void OnMouseEvent(Define.MouseEvent evt)
    {
        if (ui.DialogueMode)
            return;

        switch (evt)
        {
            case Define.MouseEvent.Hover:
                DisplayCursor();
                break;
            case Define.MouseEvent.Click:
                ClickMap(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                break;
            case Define.MouseEvent.Hold:
                break;
        }
    }

    public void StartBattle()
    {
        ClickMap(map[7, 3]);
    }

    private void ClickMap(Vector2 position)
    {
        if (GetPivotPosition(ref position))
        {
            Collider2D collider = GetColliderFromPosition(position);
            if (collider != null && mode == Mode.Select)
            {
                selectedUnit = collider.gameObject;
                DisplayMoveRange(position);
                DisplayAttackRange(position);
                GameManager.Sound.Play("Effect/Select");
                mode = Mode.Move;
            }
            else if (selectedUnit != null && mode == Mode.Move)
            {
                if (collider == null)
                {
                    if (!paths.ContainsKey(position))
                        return;

                    Vector2Int[,] parent = paths[position];
                    selectedUnit.GetComponent<UnitController>().Move(parent, position);
                    GameManager.Sound.Play("Effect/Select");
                }
                else
                {
                    // Range Attack
                }
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

    private void DisplayAttackRange(Vector2 position)
    {
        int range = mode == Mode.Select ?
            selectedUnit.GetComponent<UnitController>().MechanicStatus.RangeDistance : 1;
        enemyPosition = new();

        for (int i = -range; i <= range; i++)
        {
            for (int j = -range; j <= range; j++)
            {
                if (Math.Abs(i) + Math.Abs(j) <= range)
                {
                    Vector2 pos = new(position.x + i, position.y + j);
                    if (pos.x > mapRight || pos.x <= mapLeft ||
                        pos.y > mapTop - 2.0f || pos.y <= mapBottom + 2.0f)
                        continue;

                    Collider2D collider = GetColliderFromPosition(pos);
                    if (collider != null &&
                        collider.gameObject.GetComponent<UnitController>().Pilot.Affiliation != selectedUnit.GetComponent<UnitController>().Pilot.Affiliation)
                    {
                        enemyPosition.Add(pos);
                        GameObject attack = GameManager.Resource.Instantiate("Prefab/Attack", transform);
                        attack.transform.position = new Vector2(pos.x, pos.y);
                    }
                }
            }
        }
    }

    private void DisplayMoveRange(Vector2 position)
    {
        int speed = selectedUnit.GetComponent<UnitController>().Speed;
        int boardSize = speed * 2 + 1;
        bool[,] block = new bool[boardSize, boardSize];
        List<Vector2Int> accessPoint = new();

        for (int i = -speed; i <= speed; i++)
        {
            for (int j = -speed; j <= speed; j++)
            {
                if (Math.Abs(i) + Math.Abs(j) <= speed)
                {
                    Vector2 pos = new(position.x + i, position.y + j);
                    if (pos.x > mapRight || pos.x <= mapLeft ||
                        pos.y > mapTop - 2.0f || pos.y <= mapBottom + 2.0f)
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
                    if (collider != null &&
                        collider.gameObject.GetComponent<UnitController>().Pilot.Affiliation != selectedUnit.GetComponent<UnitController>().Pilot.Affiliation)
                    {
                        block[i + speed, j + speed] = true;
                        continue;
                    }

                    block[i + speed, j + speed] = false;
                    accessPoint.Add(new Vector2Int(i + speed, j + speed));                   
                }
            }
        }

        paths = new Dictionary<Vector2, Vector2Int[,]>();
        int[] deltaX = new int[] { 0, -1, 0, 1 };
        int[] deltaY = new int[] { -1, 0, 1, 0 };
        int cost = 1;

        Vector2Int startPoint = new(speed, speed);

        foreach (Vector2Int endPoint in accessPoint)
        {
            bool[,] closed = new bool[boardSize, boardSize];
            int[,] open = new int[boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    open[i, j] = int.MaxValue;

            Vector2Int[,] parent = new Vector2Int[boardSize, boardSize];
            Queue<Node> nodes = new();

            open[startPoint.x, startPoint.y] = Math.Abs(endPoint.x - startPoint.x) + Math.Abs(endPoint.y - startPoint.x);
            nodes.Enqueue(new Node() { F = Math.Abs(endPoint.x - startPoint.x) + Math.Abs(endPoint.y - startPoint.x), G = 0, X = startPoint.x, Y = startPoint.y });
            parent[startPoint.x, startPoint.y] = new Vector2Int(startPoint.x, startPoint.y);

            bool success = true;

            while (nodes.Count > 0)
            {
                Node node = nodes.Dequeue();

                if (closed[node.X, node.Y])
                    continue;

                closed[node.X, node.Y] = true;

                if (node.X == endPoint.x && node.Y == endPoint.y)
                    break;

                int failNumber = 0;
                for (int i = 0; i < deltaY.Length; i++)
                {
                    int nextX = node.X + deltaX[i];
                    int nextY = node.Y + deltaY[i];

                    if (nextX < 0 || nextX >= boardSize || nextY < 0 || nextY >= boardSize)
                    {
                        failNumber++;
                        continue;
                    }

                    if (block[nextX, nextY])
                    {
                        failNumber++;
                        continue;
                    }

                    if (closed[nextX, nextY])
                    {
                        failNumber++;
                        continue;
                    }

                    if (failNumber == deltaY.Length || node.G > speed)
                    {
                        success = false;
                        break;
                    }

                    int g = node.G + cost;
                    int h = Math.Abs(endPoint.x - nextX) + Math.Abs(endPoint.y - nextY);
                    if (open[nextX, nextY] < g + h)
                        continue;

                    open[nextX, nextY] = g + h;
                    nodes.Enqueue(new Node() { F = g + h, G = g, X = nextX, Y = nextY });
                    parent[nextX, nextY] = new Vector2Int(node.X, node.Y);
                }
            }

            if (success)
            {
                paths.Add(new Vector2(position.x - speed + endPoint.x, position.y - speed + endPoint.y), parent);
                GameObject move = GameManager.Resource.Instantiate("Prefab/Move", transform);
                move.transform.position = new Vector2(position.x - speed + endPoint.x, position.y - speed + endPoint.y);
            }
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
            if (!prePos.Equals(position)) GameManager.Sound.Play("Effect/Hover");
            prePos = position;
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