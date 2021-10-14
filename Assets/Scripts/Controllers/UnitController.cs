using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public Character Pilot;
    public CharacterStatus PilotStatus;
    public MechanicStatus MechanicStatus;

    public int Speed { get { return MechanicStatus.Speed; } }

    public void InitUnit(Define.Character pilot, Define.Mechanic mechanic)
    {
        Pilot = GameManager.Data.Characters[pilot];
        PilotStatus = GameManager.Status.CharStatusDic[pilot];
        MechanicStatus = GameManager.Status.MechaStatusDic[mechanic];

        gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Resource.Load<Sprite>("Icons/" + mechanic.ToString());
    }
}