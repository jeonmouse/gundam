using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnglishScript : BaseScript
{
    public override List<Script> Init(Define.Scene scene)
    {
        return scene switch
        {
            Define.Scene.TemRayRoom => GetTemRayRoomScript(),
            Define.Scene.GundamFactory => GetGundamFactoryScript(),
            _ => null,
        };
    }

    public override List<Script> Init(Define.Dialogue dialogue)
    {
        return dialogue switch
        {
            Define.Dialogue.AmuroRideGundam => GetAmuroRideGundamScript(),
            Define.Dialogue.MainCharacterRideGundam => GetMainCharacterRideGundam(),
            _ => null,
        };
    }

    public List<Script> GetMainCharacterRideGundam()
    {
        List<Script> scripts = new();

        return scripts;
    }

    public List<Script> GetAmuroRideGundamScript()
    {
        List<Script> scripts = new();

        return scripts;
    }

    public List<Script> GetTemRayRoomScript()
    {
        List<Script> scripts = new();

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "Excuse me, Lieutenant Ray, We're docking at Side 7 now. Please report to the bridge at once."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "Tem",
            Content = "Very well. Your name is <MainCharacter>, isn't it?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "Yes, Sir."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "Tem",
            Content = "How long have you been in the military?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "6 months, sir."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "Tem",
            Content = "Once we mass-produce the Gundam, we'll be able to end the war without sending young men like you into battle."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "That picture is..."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Select2,
            Place = Script.Position.Right,
            Event = Define.DialogueEvent.AskAmuroName,
            Speaker = "<MainCharacter>",
            Content = "Your son, sir?/Maybe your son. What's his name?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "Tem",
            Content = "Yes. I hear there are boys his age fighting as guerrillas. Is that true?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "Tem",
            Content = "His name is Amuro. I hear there are boys his age fighting as guerrillas. Is that true?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "Yes, I'm told that it happens."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "Tem",
            Content = "How terrible."
        });

        return scripts;
    }

    public List<Script> GetGundamFactoryScript()
    {
        List<Script> scripts = new();

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "Lieutenant Farrell, we've completed the inspection of Gundam 1"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "Farrell",
            Content = "Thank you. Let's go back to Whitebase."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "... Lieutenant Farrell."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "Farrell",
            Content = "Why, what's wrong?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "Can I stay on board while Gundam is loaded on the white base?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "Farrell",
            Content = "What does that mean?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "I'm a candidate pilot, so I don't think I'll have many chances to board, so I'd like to ride it now!"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "Farrell",
            Content = "You'd be dizzy if you were lying in the cockpit."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "It's all right. Don't worry!"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "Farrell",
            Content = "Okay, I'll meet you in Whitebase."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "Thank you!"
        });

        return scripts;
    }
}
