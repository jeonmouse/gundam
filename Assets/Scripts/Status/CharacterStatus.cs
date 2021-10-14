using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus
{
    public string EnName;
    public string JpName;
    public string KrName;
    public int Technic;
    public int Concentration;
    public int Reflex;
    public int Leadership;
    public int Management;
    public int Judgement;

    public CharacterStatus(Define.Character character)
    {
        switch (character)
        {
            case Define.Character.BrightNoa:
                EnName = "Bright";
                JpName = "ブライト";
                KrName = "브라이트";
                Technic = 13;
                Concentration = 14;
                Reflex = 12;
                Leadership = 18;
                Management = 18;
                Judgement = 17;
                break;
            case Define.Character.RhysJeon:
                EnName = "Rhys";
                JpName = "リース";
                KrName = "리스";
                Technic = 16;
                Concentration = 15;
                Reflex = 19;
                Leadership = 18;
                Management = 14;
                Judgement = 20;
                break;
            case Define.Character.DominickWilliam:
                EnName = "Dominick";
                JpName = "ドミニク";
                KrName = "도미닉";
                Technic = 18;
                Concentration = 18;
                Reflex = 18;
                Leadership = 16;
                Management = 14;
                Judgement = 13;
                break;
            case Define.Character.LeonMarcenas:
                EnName = "Leon";
                JpName = "レオン";
                KrName = "레온";
                Technic = 17;
                Concentration = 20;
                Reflex = 18;
                Leadership = 14;
                Management = 16;
                Judgement = 17;
                break;
            case Define.Character.AmuroRay:
                EnName = "Amuro";
                JpName = "アムロ";
                KrName = "아무로";
                Technic = 20;
                Concentration = 20;
                Reflex = 20;
                Leadership = 17;
                Management = 15;
                Judgement = 18;
                break;
        }
    }
}
