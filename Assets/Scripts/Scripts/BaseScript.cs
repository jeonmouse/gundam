using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScript
{
    public abstract List<Script> Init(Define.Scene scene);

    public abstract List<Script> Init(Define.Dialogue dialogue);
}

public class Script
{
    public enum Position
    {
        Left,
        Right,
        Battle
    }

    public enum DialogType
    {
        Normal,
        Select2
    }

    public Position Place;
    public DialogType Type;
    public string Speaker;
    public string Content;
    public Define.DialogueEvent Event = Define.DialogueEvent.None;
}
