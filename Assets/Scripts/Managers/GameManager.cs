using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    DataManager data = new();
    public static DataManager Data { get { return instance.data; } }

    InputManager input = new();
    public static InputManager Input { get { return instance.input; } }

    ResourceManager resource = new();
    public static ResourceManager Resource { get { return instance.resource; } }

    SoundManager sound = new();
    public static SoundManager Sound { get { return instance.sound; } }

    StatusManager status = new();
    public static StatusManager Status { get { return instance.status; } }

    ScriptManager script = new();
    public static ScriptManager Script { get { return instance.script; } }

    private void Awake()
    {
        Application.targetFrameRate = 30;

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        instance.data.Init();
        instance.sound.Init();
        instance.status.Init();

        // DEL?
        instance.data.SetLanguage(Data.Environment.Language);
    }

    private void Update()
    {
        input.OnUpdate();
    }

    private void OnApplicationQuit()
    {
        data.SaveEnvironment();
    }

    public static void Clear()
    {
        Input.Clear();
        Sound.Clear();
    }
}
