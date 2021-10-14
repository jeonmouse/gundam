using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager
{
    public Dictionary<Define.Character, CharacterStatus> CharStatusDic = new Dictionary<Define.Character, CharacterStatus>();
    public Dictionary<Define.Mechanic, MechanicStatus> MechaStatusDic = new Dictionary<Define.Mechanic, MechanicStatus>();

    public void Init()
    {
        foreach (Define.Character character in Enum.GetValues(typeof(Define.Character)))
        {
            CharStatusDic.Add(character, new CharacterStatus(character));
        }

        foreach (Define.Mechanic mechanic in Enum.GetValues(typeof(Define.Mechanic)))
        {
            MechaStatusDic.Add(mechanic, new MechanicStatus(mechanic));
        }
    }
}
