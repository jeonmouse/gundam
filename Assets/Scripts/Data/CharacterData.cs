using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterData : ILoader<string, Character>
{
    public List<Character> Characters = new List<Character>();

    public Dictionary<string, Character> MakeDic()
    {
        Dictionary<string, Character> dic = new Dictionary<string, Character>();
        foreach (Character character in Characters)
            dic.Add(character.Name, character);
        return dic;
    }
}

[Serializable]
public class Character
{
    public string Name;
    public Define.Rank Rank;
    public int Level;
    public int ShotDownNumber;
    public int Exp;
}
