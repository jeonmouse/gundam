using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static T GetOrAddComponent<T>(GameObject gameObject) where T : UnityEngine.Component
    {
        T component = gameObject.GetComponent<T>();
        if (component == null)
            component = gameObject.AddComponent<T>();
        return component;
    }

    public static GameObject FindChild(GameObject root, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(root, name, recursive);
        if (transform == null) return null;
        return transform.gameObject;
    }

    public static T FindChild<T>(GameObject root, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (root == null)
            return null;

        if (!recursive)
        {
            for (int i = 0; i < root.transform.childCount; i++)
            {
                Transform transform = root.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else
        {
            foreach (T component in root.GetComponentsInChildren<T>())
            {
                if (component.name == name)
                    return component;
            }
        }

        return null;
    }

    public static string GetMainCharacterName(Define.Language language, Define.Character mainChar)
    {
        if (language == Define.Language.English)
        {
            if (mainChar == Define.Character.BrightNoa)
                return "Bright";
            else if (mainChar == Define.Character.RhysJeon)
                return "Rhys";
            else if (mainChar == Define.Character.DominickWilliam)
                return "Dominick";
            else
                return "Leon";
        }
        else if (language == Define.Language.Japanese)
        {
            if (mainChar == Define.Character.BrightNoa)
                return "????????????";
            else if (mainChar == Define.Character.RhysJeon)
                return "?????????";
            else if (mainChar == Define.Character.DominickWilliam)
                return "????????????";
            else
                return "?????????";
        }
        else
        {
            if (mainChar == Define.Character.BrightNoa)
                return "????????????";
            else if (mainChar == Define.Character.RhysJeon)
                return "??????";
            else if (mainChar == Define.Character.DominickWilliam)
                return "?????????";
            else
                return "??????";
        }
    }

    public static Define.Character DefineCharacter(string name)
    {
        switch (name)
        {
            case "<MainCharacter>":
            case "Select2":
            case "Select3":
                return GameManager.Data.Common.MainCharacter;
            case "???":
            case "Tem":
            case "??????":
                return Define.Character.TemRay;
            case "??????":
            case "Farrell":
            case "????????????":
                return Define.Character.FarrellIha;
            default:
                return Define.Character.Nobody;

        }
    }
}
