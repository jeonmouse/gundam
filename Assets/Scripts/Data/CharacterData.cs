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

    public void SaveToList(Dictionary<Define.Character, Character> dic)
    {
        Characters.Clear();

        foreach (Character character in dic.Values)
        {
            Characters.Add(character);
        }
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

    public Character(Define.Character character, Define.Affiliation affiliation, Define.Rank rank, 
        int pilotLevel, int captainLevel)
    {
        ID = character;
        Affiliation = affiliation;
        Rank = rank;
        PilotLevel = pilotLevel;
        PilotExperience = 0;
        CaptainLevel = captainLevel;
        CaptainExperience = 0;
        ShotDownNumber = 0;
    }
}
