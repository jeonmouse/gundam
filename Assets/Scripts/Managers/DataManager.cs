using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager
{
    public EnvironmentData Environment;

    public void Init()
    {
        TextAsset textAsset = GameManager.Resource.Load<TextAsset>("Data/Environment");
        //EnvironmentData environment = new EnvironmentData();
        //environment.Language = Define.Language.Korean;
        //environment.MainCharacter = Define.MainCharacter.Bright;
        //File.WriteAllText("Assets/Resources/Data/Environment.json", JsonUtility.ToJson(environment));

        Environment = JsonUtility.FromJson<EnvironmentData>(textAsset.text);
    }
}
