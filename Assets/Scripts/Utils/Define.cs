using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Language
    {
        English,
        Japanese,
        Korean
    }

    public enum MainCharacter
    {
        BrightNoa,
        RhysJeon,
        DominickWilliam,
        LeonMarcenas
    }

    public enum MouseEvent
    {
        Press,
        Down,
        Up,
        Hold,
        Click
    }

    public enum UIEvent
    {
        Click,
        Hover
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount
    }

    public enum Rank
    {
        SeamanRecruit,
        SeamanApprentice,
        Seaman,
        PettyOfficer2ndClass,
        WarrantOfficer,
        PettyOfficer1stClass,
        ChiefPettyOfficer,
        SeniorChiefPettyOfficer,
        Ensign,
        LieutenantJuniorGrade,
        Lieutenant,
        LieutenantCommander,
        Commander,
        Captain,
        RearAdmiralLower,
        RearAdmiral,
        ViceAdmiral,
        Admiral
    }

    public enum Dialogue
    {
        TemRayRoom = 0,
        GundamFactory
    }

    public enum DialogueEvent
    {
        AskAmuroName = 7
    }
}
