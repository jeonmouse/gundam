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

    public enum Character
    {
        Nobody = 0,
        BrightNoa = 1, RhysJeon = 2, DominickWilliam = 3, LeonMarcenas = 4,
        AmuroRay = 5,
        TemRay = 5001, FarrellIha = 5002,
        Denim = 15001, Gene = 15002
    }

    public enum Mechanic
    {
        Gundam1,
        Gundam2,
        Zaku2
    }

    public enum Affiliation
    {
        EFSF,
        Zeon
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

    public enum MouseEvent
    {
        Press,
        Down,
        Up,
        Hold,
        Click,
        Hover
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
    

    public enum Dialogue
    {
        TemRayRoom = 0,
        GundamFactory = 1000
    }

    public enum DialogueEvent
    {
        AskAmuroName = 7
    }

    public enum DialoguePosition
    {
        Left = 0,
        Right = 1
    }

    public enum Battle
    {
        GundamRising
    }
}
