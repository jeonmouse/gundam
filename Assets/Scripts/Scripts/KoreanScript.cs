using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoreanScript : BaseScript
{
    public override Dictionary<int, Script> Init(Define.Dialogue dialogue)
    {
        return dialogue switch
        {
            Define.Dialogue.TemRayRoom => GetTemRayRoomScript(),
            Define.Dialogue.GundamFactory => GetGundamFactoryScript(),
            _ => null,
        };
    }

    public Dictionary<int, Script> GetTemRayRoomScript()
    {
        Dictionary<int, Script> scripts = new();

        scripts.Add(0, new Script() {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "레이 대위님, 사이드 7에 입항했습니다. 즉시 브릿지로 와 주십시오"
        });

        scripts.Add(1, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "템",
            Content = "음. 알았네. <MainCharacter> 군이라고 했나?"
        });

        scripts.Add(2, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "예 대위님"
        });

        scripts.Add(3, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "템",
            Content = "입대한 지는 얼마나 됐지?"
        });

        scripts.Add(4, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "6개월 되었습니다"
        });

        scripts.Add(5, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "템",
            Content = "건담이 양산되면 자네같은 젊은 친구들이 안 싸워도 전쟁은 끝날 걸세"
        });

        scripts.Add(6, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "저 사진은..."
        });

        scripts.Add(7, new Script()
        {
            Type = Script.DialogType.Select2,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "아드님이십니까?/아드님이시군요. 이름은 어떻게 되나요?"
        });

        scripts.Add(8, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "템",
            Content = "그래, 이런 어린애들도 게릴라로 싸운다던데 정말인가?"
        });

        scripts.Add(9, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "템",
            Content = "아, 아무로라네. 이런 어린애들도 게릴라로 싸운다던데 정말인가?"
        });

        scripts.Add(10, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "네, 그렇다고 합니다"
        });

        scripts.Add(11, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "템",
            Content = "끔찍하군"
        });

        return scripts;
    }

    public Dictionary<int, Script> GetGundamFactoryScript()
    {
        Dictionary<int, Script> scripts = new();

        scripts.Add(0, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "???? ??????, ???? 1???? ???? ???? ??????????"
        });

        scripts.Add(1, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "????",
            Content = "????????. ???? ?????????????? ????????"
        });

        scripts.Add(2, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "??... ???? ??????"
        });

        scripts.Add(3, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "????",
            Content = "??, ?????? ?????"
        });

        scripts.Add(4, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "?????? ?????????????? ???????? ???? ???? ???? ?????? ???????"
        });

        scripts.Add(5, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "????",
            Content = "???? ?????? ?????"
        });

        scripts.Add(6, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "???? ???? ?????????? ?????? ?????? ???? ???? ?? ???? ?????????? ?????? ????????!"
        });

        scripts.Add(7, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "????",
            Content = "?????? ???? ?????? ?????????????"
        });

        scripts.Add(10, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "??????????. ??????????!"
        });

        scripts.Add(11, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "????",
            Content = "???? ??????. ???????????????? ??????"
        });

        scripts.Add(12, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "??????????!"
        });

        return scripts;
    }
}
