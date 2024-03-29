using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoreanScript : BaseScript
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

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Battle,
            Speaker = "<MainCharacter>",
            Content = "어떻게 자쿠가 여기에..."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Battle,
            Speaker = "<MainCharacter>",
            Content = "이대로 있다간 다 죽겠어."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Battle,
            Speaker = "<MainCharacter>",
            Content = "중위님께는 미안하지만 내가 먼저다!"
        });

        return scripts;
    }

    public List<Script> GetAmuroRideGundamScript()
    {
        List<Script> scripts = new();

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Battle,
            Speaker = "아무로",
            Content = "이녀석, 작동하잖아."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Battle,
            Speaker = "아무로",
            Content = "굉장해. 5배 이상의 에너지 게인이 있어."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Battle,
            Speaker = "아무로",
            Content = "해 보겠어."
        });

        return scripts;
    }

    public List<Script> GetTemRayRoomScript()
    {
        List<Script> scripts = new();

        scripts.Add(new Script() {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "레이 대위님, 사이드 7에 입항했습니다. 즉시 브릿지로 와 주십시오."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "템",
            Content = "음. 알았네. <MainCharacter> 군이라고 했나?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "예 대위님."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "템",
            Content = "입대한 지는 얼마나 됐지?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "6개월 되었습니다."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "템",
            Content = "건담이 양산되면 자네같은 젊은 친구들이 안 싸워도 전쟁은 끝날 걸세."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "저 사진은..."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Select2,
            Place = Script.Position.Right,
            Event = Define.DialogueEvent.AskAmuroName,
            Speaker = "<MainCharacter>",
            Content = "아드님이십니까?/아드님이시군요. 이름은 어떻게 되나요?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "템",
            Content = "그래, 이런 어린애들도 게릴라로 싸운다던데 정말인가?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "템",
            Content = "아, 아무로라네. 이런 어린애들도 게릴라로 싸운다던데 정말인가?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "네, 그렇다고 합니다."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "템",
            Content = "끔찍하군."
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
            Content = "파렐 중위님, 건담 1호기 점검 완료 하였습니다."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "파렐",
            Content = "수고했다. 이제 화이트베이스로 돌아가자."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "저... 파렐 중위님."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "파렐",
            Content = "왜, 무슨일 있나?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "건담을 화이트베이스로 탑재하는 동안 제가 타고 있어도 될까요?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "파렐",
            Content = "무슨 소린가 그게?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "저는 후보 파일럿이라 탑승할 기회가 많이 없을 것 같아 지금이라도 타보고 싶습니다!"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "파렐",
            Content = "누워서 타고 있으면 어지러울텐데?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "괜찮습니다. 걱정마십쇼!"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "파렐",
            Content = "그래 알겠다. 화이트베이스에서 만나자."
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "감사합니다!"
        });

        return scripts;
    }
}
