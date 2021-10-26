using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScript
{
    public abstract Dictionary<int, Script> Init(Define.Dialogue dialogue);
}

public class Script
{
    public enum Position
    {
        Left,
        Right
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
}
