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
    public Dictionary<Define.Character, Character> Characters { get; set; } = new Dictionary<Define.Character, Character>();

    // DEL?
    public Dictionary<int, OldScript> Scripts { get; set; } = new Dictionary<int, OldScript>();

    public void Init()
    {
        Environment = LoadJson<EnvironmentData>("Environment");
        if (Environment == null)
            Environment = new EnvironmentData { Language = Define.Language.English };
        Common = new CommonData();
    }

    // DEL?
    public void SetLanguage(Define.Language language)
    {
        Scripts.Clear();
        Scripts = LoadJson<ScriptData, int, OldScript>(language.ToString()).MakeDic();
    }

    public void Load(int index)
    {
        Common = LoadJson<CommonData>("Common");
        Characters = LoadJson<CharacterData, Define.Character, Character>("Character").MakeDic();
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

    public void SetEventFlag(Define.DialogueEvent evt, int select)
    {
        switch (evt)
        {
            case Define.DialogueEvent.AskAmuroName:
                if (select == 1)
                    Common.AskAmuroName = false;
                else
                    Common.AskAmuroName = true;
                break;
        }
    }
}
