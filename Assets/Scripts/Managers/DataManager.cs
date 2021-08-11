using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDic();
}

public class DataManager
{
    public EnvironmentData Environment { get; set; }
    public CommonData Common { get; set; }
    public Dictionary<string, Character> Characters { get; set; } = new Dictionary<string, Character>();
    public Dictionary<int, Script> Scripts { get; set; } = new Dictionary<int, Script>();

    public void Init()
    {
        Environment = LoadJson<EnvironmentData>("Environment");
        Common = new CommonData();
    }

    public void SetLanguage(Define.Language language)
    {
        Scripts = LoadJson<ScriptData, int, Script>(language.ToString()).MakeDic();
    }

    public void Load(int index)
    {
        Common = LoadJson<CommonData>("Common");
        Characters = LoadJson<CharacterData, string, Character>("Character").MakeDic();
    }

    public void SaveEnvironment()
    {
        File.WriteAllText("Assets/Resources/Data/Environment.json", JsonUtility.ToJson(Environment));
    }

    private T LoadJson<T>(string path)
    {
        TextAsset textAsset = GameManager.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<T>(textAsset.text);
    }

    private Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = GameManager.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
