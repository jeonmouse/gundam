using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public Character Pilot;
    public CharacterStatus PilotStatus;
    public MechanicStatus MechanicStatus;

    private List<Vector2> movePoints = new();
    private int moveIndex = 0;

    public int Speed { get { return MechanicStatus.Speed; } }

    public void InitUnit(Define.Character pilot, Define.Mechanic mechanic)
    {
        Pilot = GameManager.Data.Characters[pilot];
        PilotStatus = GameManager.Status.CharStatusDic[pilot];
        MechanicStatus = GameManager.Status.MechaStatusDic[mechanic];

        gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Resource.Load<Sprite>("Icons/" + mechanic.ToString());
    }

    public void Move(Vector2Int[,] parent, Vector2 destination)
    {
        if (transform.position == (Vector3)destination)
            return;

        int x = (int)Math.Round(destination.x - transform.position.x) + Speed;
        int y = (int)Math.Round(destination.y - transform.position.y) + Speed;
        while (parent[x, y].x != x || parent[x, y].y != y)
        {
            movePoints.Add(new Vector2(x - parent[x, y].x, y - parent[x, y].y));
            Vector2Int pos = parent[x, y];
            x = pos.x;
            y = pos.y;
        }
        movePoints.Reverse();
    }

    public void Update()
    {
        if (movePoints.Count > 0)
        {
            if (moveIndex >= movePoints.Count)
            {
                moveIndex = 0;
                movePoints.Clear();
                return;
            }

            transform.Translate(movePoints[moveIndex]);
            moveIndex++;
        }
    }
}