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

    InputManager input = new InputManager();
    public static InputManager Input { get { return Instance.input; } }

    ResourceManager resource = new ResourceManager();
    public static ResourceManager Resource { get { return Instance.resource; } }

    SoundManager sound = new SoundManager();
    public static SoundManager Sound { get { return Instance.sound; } }

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

        instance.sound.Init();
    }

    public static void Clear()
    {
        Input.Clear();
        Sound.Clear();
    }

    public enum Language
    {
        English,
        Japanese,
        Korean
    }
    public Language LanguageSetting { get; set; } = Language.Korean;    
}
