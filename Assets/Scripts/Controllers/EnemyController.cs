using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : UnitController
{
    public void Init(Define.Character pilot, Define.Mechanic mechanic, Define.Affiliation affiliation, Define.Rank rank, int pilotLevel, int captainLevel)
    {
        Pilot = new Character(pilot, affiliation, rank, pilotLevel, captainLevel);
        PilotStatus = GameManager.Status.CharStatusDic[pilot];
        MechanicStatus = GameManager.Status.MechaStatusDic[mechanic];

        gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Resource.Load<Sprite>("Icons/" + mechanic.ToString());
    }
}
