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
            case Define.Character.AmuroRayYoung:
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
            case Define.Character.AmuroRayTutorial:
                EnName = "Amuro";
                JpName = "アムロ";
                KrName = "아무로";
                Technic = 13;
                Concentration = 13;
                Reflex = 13;
                Leadership = 12;
                Management = 10;
                Judgement = 13;
                break;
            case Define.Character.CharAznable:
                EnName = "Char";
                JpName = "シャア";
                KrName = "샤아";
                Technic = 19;
                Concentration = 18;
                Reflex = 19;
                Leadership = 19;
                Management = 17;
                Judgement = 20;
                break;
            case Define.Character.Denim:
                EnName = "Denim";
                JpName = "デニム";
                KrName = "데님";
                Technic = 12;
                Concentration = 13;
                Reflex = 11;
                Leadership = 12;
                Management = 10;
                Judgement = 10;
                break;
            case Define.Character.Gene:
                EnName = "Gene";
                JpName = "ジーン";
                KrName = "진";
                Technic = 11;
                Concentration = 9;
                Reflex = 8;
                Leadership = 11;
                Management = 10;
                Judgement = 7;
                break;
        }
    }
}
