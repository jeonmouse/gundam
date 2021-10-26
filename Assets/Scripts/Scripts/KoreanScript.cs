using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoreanScript : BaseScript
{
    public override Dictionary<int, Script> Init(Define.Dialogue dialogue)
    {
        switch (dialogue)
        {
            case Define.Dialogue.TemRayRoom:
                return GetTemRayRoomScripts();
            case Define.Dialogue.GundamFactory:
                return GetGundamFactoryScripts();
            default:
                return null;
        }
    }

    public Dictionary<int, Script> GetTemRayRoomScripts()
    {
        Dictionary<int, Script> scripts = new();

        scripts.Add(0, new Script() {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "���� ������, ���̵� 7�� �����߽��ϴ�. ��� �긴���� �� �ֽʽÿ�"
        });

        scripts.Add(1, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "��",
            Content = "��. �˾ҳ�. <MainCharacter> ���̶�� �߳�?"
        });

        scripts.Add(2, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "�� ������"
        });

        scripts.Add(3, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "��",
            Content = "�Դ��� ���� �󸶳� ����?"
        });

        scripts.Add(4, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "6���� �Ǿ����ϴ�"
        });

        scripts.Add(5, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "��",
            Content = "�Ǵ��� ���Ǹ� �ڳװ��� ���� ģ������ �� �ο��� ������ ���� �ɼ�"
        });

        scripts.Add(6, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "�� ������..."
        });

        scripts.Add(7, new Script()
        {
            Type = Script.DialogType.Select2,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "�Ƶ���̽ʴϱ�?/�Ƶ���̽ñ���. �̸��� ��� �ǳ���?"
        });

        scripts.Add(8, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "��",
            Content = "�׷�, �̷� ��ֵ鵵 �Ը���� �ο�ٴ��� �����ΰ�?"
        });

        scripts.Add(9, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "��",
            Content = "��, �ƹ��ζ��. �̷� ��ֵ鵵 �Ը���� �ο�ٴ��� �����ΰ�?"
        });

        scripts.Add(10, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "��, �׷��ٰ� �մϴ�"
        });

        scripts.Add(11, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "��",
            Content = "�����ϱ�"
        });

        return scripts;
    }

    public Dictionary<int, Script> GetGundamFactoryScripts()
    {
        Dictionary<int, Script> scripts = new();

        scripts.Add(0, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "�ķ� ������, �Ǵ� 1ȣ�� ���� �Ϸ� �Ͽ����ϴ�"
        });

        scripts.Add(1, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "�ķ�",
            Content = "�����ߴ�. ���� ȭ��Ʈ���̽��� ���ư���"
        });

        scripts.Add(2, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "��... �ķ� ������"
        });

        scripts.Add(3, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "�ķ�",
            Content = "��, ������ �ֳ�?"
        });

        scripts.Add(4, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "�Ǵ��� ȭ��Ʈ���̽��� ž���ϴ� ���� ���� Ÿ�� �־ �ɱ��?"
        });

        scripts.Add(5, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "�ķ�",
            Content = "���� �Ҹ��� �װ�?"
        });

        scripts.Add(6, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "���� �ĺ� ���Ϸ��̶� ž���� ��ȸ�� ���� ���� �� ���� �����̶� Ÿ���� �ͽ��ϴ�!"
        });

        scripts.Add(7, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "�ķ�",
            Content = "������ Ÿ�� ������ ���������ٵ�?"
        });

        scripts.Add(10, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "�������ϴ�. �������ʼ�!"
        });

        scripts.Add(11, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Left,
            Speaker = "�ķ�",
            Content = "�׷� �˰ڴ�. ȭ��Ʈ���̽����� ������"
        });

        scripts.Add(12, new Script()
        {
            Type = Script.DialogType.Normal,
            Place = Script.Position.Right,
            Speaker = "<MainCharacter>",
            Content = "�����մϴ�!"
        });

        return scripts;
    }
}
