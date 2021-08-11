using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIBase : MonoBehaviour
{
    private Dictionary<Type, UnityEngine.Object[]> dic = new Dictionary<Type, UnityEngine.Object[]>();

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        dic.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = Util.FindChild(gameObject, names[i], true);
            else
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
        }
    }

    protected Text GetText(int index) { return Get<Text>(index); }
    protected Button GetButton(int index) { return Get<Button>(index); }
    protected Image GetImage(int index) { return Get<Image>(index); }
    protected RawImage GetRawImage(int index) { return Get<RawImage>(index); }
    protected GameObject GetGameObject(int index) { return Get<GameObject>(index); }

    protected T Get<T>(int index) where T : UnityEngine.Object
    {
        if (dic.TryGetValue(typeof(T), out UnityEngine.Object[] objects) == false)
            return null;

        return objects[index] as T;
    }

    protected T[] GetAll<T>() where T : UnityEngine.Object
    {
        int count = dic[typeof(T)].Length;
        UnityEngine.Object[] objects = dic[typeof(T)];
        T[] texts = new T[count];

        for (int i = 0; i < count; i++)
        {
            texts[i] = objects[i] as T;
        }

        return texts;
    }

    public static void BindEvent(GameObject gameObject, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UIEventHandler eventHandler = Util.GetOrAddComponent<UIEventHandler>(gameObject);

        switch (type)
        {
            case Define.UIEvent.Click:
                eventHandler.ClickAction -= action;
                eventHandler.ClickAction += action;
                break;
            case Define.UIEvent.Hover:
                eventHandler.HoverAction -= action;
                eventHandler.HoverAction += action;
                break;
        }
    }
}
