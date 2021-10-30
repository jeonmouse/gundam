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
        Nobody,
        BrightNoa, RhysJeon, DominickWilliam, LeonMarcenas,
        AmuroRay, AmuroRayYoung,
        TemRay, FarrellIha, AmuroRayTutorial,
        CharAznable,
        Denim, Gene
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

    public enum War
    {
        TheOneYearWar
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
    

    public enum Scene
    {
        TemRayRoom,
        GundamFactory,
        GundamRising
    }

    public enum Dialogue
    {
        MainCharacterRideGundam,
        AmuroRideGundam
    }

    public enum DialogueEvent
    {
        AskAmuroName,
        None
    }

    public enum DialoguePosition
    {
        Left,
        Right
    }
}
