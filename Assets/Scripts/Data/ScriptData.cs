using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DEL?
[Serializable]
public class ScriptData : ILoader<int, OldScript>
{
    public List<OldScript> Scripts = new List<OldScript>();

    public Dictionary<int, OldScript> MakeDic()
    {
        Dictionary<int, OldScript> dic = new Dictionary<int, OldScript>();
        foreach (OldScript script in Scripts)
            dic.Add(script.Number, script);
        return dic;
    }
}

// DEL?
[Serializable]
public class OldScript
{
    public int Number;
    public int Position;
    public string Speaker;
    public string Content;
}

