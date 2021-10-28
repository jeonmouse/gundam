using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager
{
    public List<Script> GetScripts(Define.Language language, Define.Dialogue dialogue)
    {
        switch (language)
        {
            case Define.Language.English:
                EnglishScript english = new();
                return english.Init(dialogue);
            case Define.Language.Japanese:
                JapaneseScript japanese = new();
                return japanese.Init(dialogue);
            case Define.Language.Korean:
                KoreanScript korean = new();
                return korean.Init(dialogue);
            default:
                return null;
        }
    }
}
