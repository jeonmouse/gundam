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

    public static string GetMainCharacterName(Define.Language language, Define.MainCharacter mainChar)
    {
        if (language == Define.Language.English)
        {
            if (mainChar == Define.MainCharacter.BrightNoa)
                return "Bright";
            else if (mainChar == Define.MainCharacter.RhysJeon)
                return "Rhys";
            else if (mainChar == Define.MainCharacter.DominickWilliam)
                return "Dominick";
            else
                return "Leon";
        }
        else if (language == Define.Language.Japanese)
        {
            if (mainChar == Define.MainCharacter.BrightNoa)
                return "ブライト";
            else if (mainChar == Define.MainCharacter.RhysJeon)
                return "リース";
            else if (mainChar == Define.MainCharacter.DominickWilliam)
                return "ドミニク";
            else
                return "レオン";
        }
        else
        {
            if (mainChar == Define.MainCharacter.BrightNoa)
                return "브라이트";
            else if (mainChar == Define.MainCharacter.RhysJeon)
                return "리스";
            else if (mainChar == Define.MainCharacter.DominickWilliam)
                return "도미닉";
            else
                return "레온";
        }
    }
}
