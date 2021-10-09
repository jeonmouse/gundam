using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScriptData : ILoader<int, Script>
{
    public List<Script> Scripts = new List<Script>();

    public Dictionary<int, Script> MakeDic()
    {
        Dictionary<int, Script> dic = new Dictionary<int, Script>();
        foreach (Script script in Scripts)
            dic.Add(script.Number, script);
        return dic;
    }
}

[Serializable]
public class Script
{
    public int Number;
    public int Position;
    public string Speaker;
    public string Content;
}
