using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager
{
    public Dictionary<Define.Character, CharacterStatus> CharStatusDic = new Dictionary<Define.Character, CharacterStatus>();

    public void Init()
    {
        foreach (Define.Character character in Enum.GetValues(typeof(Define.Character)))
        {
            CharStatusDic.Add(character, new CharacterStatus(character));
        }
    }
}
