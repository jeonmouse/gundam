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

    DataManager data = new DataManager();
    public static DataManager Data { get { return instance.data; } }

    InputManager input = new InputManager();
    public static InputManager Input { get { return instance.input; } }

    ResourceManager resource = new ResourceManager();
    public static ResourceManager Resource { get { return instance.resource; } }

    SoundManager sound = new SoundManager();
    public static SoundManager Sound { get { return instance.sound; } }

    private void Awake()
    {
        Application.targetFrameRate = 30;

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        instance.data.Init();
        instance.sound.Init();
        LanguageSetting = Data.Environment.Language;
    }

    public static void Clear()
    {
        Input.Clear();
        Sound.Clear();
    }

    public Define.Language LanguageSetting { get; set; }
}
