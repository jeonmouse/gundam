using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager
{
    public Dictionary<int, Script> GetScriptDic(Define.Language language, Define.Dialogue dialogue)
    {
        switch (language)
        {
            case Define.Language.English:
                return null;
            case Define.Language.Japanese:
                return null;
            case Define.Language.Korean:
                KoreanScript korean = new();
                return korean.Init(dialogue);
            default:
                return null;
        }
    }
}
