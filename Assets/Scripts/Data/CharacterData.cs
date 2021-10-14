using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterData : ILoader<Define.Character, Character>
{
    public List<Character> Characters = new();

    public Dictionary<Define.Character, Character> MakeDic()
    {
        Dictionary<Define.Character, Character> dic = new();
        foreach (Character character in Characters)
            dic.Add(character.ID, character);
        return dic;
    }
}

[Serializable]
public class Character
{
    public Define.Character ID;
    public Define.Affiliation Affiliation;
    public Define.Rank Rank;
    public int PilotLevel;
    public int PilotExperience;
    public int CaptainLevel;
    public int CaptainExperience;
    public int ShotDownNumber;
}
