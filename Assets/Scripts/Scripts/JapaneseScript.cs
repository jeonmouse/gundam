using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JapaneseScript : BaseScript
{
    public override List<Script> Init(Define.Dialogue dialogue)
    {
        return dialogue switch
        {
            Define.Dialogue.TemRayRoom => GetTemRayRoomScript(),
            Define.Dialogue.GundamFactory => GetGundamFactoryScript(),
            _ => null,
        };
    }

    public List<Script> GetTemRayRoomScript()
    {
        List<Script> scripts = new();

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "伝令。レイ大尉、サイド７へ入港いたしました。至急、ブリッジへおいでください。"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "テム",
            Content = "ん、了解した, <MainCharacter>君といったね?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "はい。"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "テム",
            Content = "何ヶ月になるね？軍に入って?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "6ヶ月であります。"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "テム",
            Content = "ガンダムが量産されるようになれば、君のような若者が実戦に出なくとも戦争は終わろう。"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "あの写真は···"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Select2,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "お子様でらっしゃいますか？/息子さんですね。 お名前は何ですか?"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "テム",
            Content = "ああ。こんな歳の子がゲリラ戦に出ているとの噂も聞くが、本当かね？"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "テム",
            Content = "アムロです。 こんな歳の子がゲリラ戦に出ているとの噂も聞くが、本当かね？"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "はい、事実だそうであります。"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "テム",
            Content = "嫌だねえ。"
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
            Content = "ファレル中尉のガンダム1号機、点検完了しました。"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "ファレル",
            Content = "お疲れさま、もうホワイトベースに戻ろう。"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "あの…ファレル中尉様。"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "ファレル",
            Content = "何、何かあったの？"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "ガンダムをホワイトベースで搭載する間、私が乗っていてもいいですか。"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "ファレル",
            Content = "何言ってるの？"
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
            Speaker = "ファレル",
            Content = "コックピットに横になって乗っていたらくらくらするんじゃない？"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "大丈夫です。心配しないでください!"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "ファレル",
            Content = "そうわかった。ホワイトベースで会おうね。"
        });

        scripts.Add(new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "ありがとうございました！"
        });

        return scripts;
    }
}
