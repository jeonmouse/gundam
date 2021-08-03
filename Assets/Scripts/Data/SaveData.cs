using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public Define.MainCharacter MainCharacter;
    public List<Character> Characters;
}

[Serializable]
public class Character
{
    public int Name;
}
