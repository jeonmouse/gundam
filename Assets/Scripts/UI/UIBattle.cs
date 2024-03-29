using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattle : UIBase
{
    private List<Script> scripts;
    private int scriptNum = 0;

    public bool DialogueMode { get; set; } = false;
    public Action StartBattle;

    private enum Texts
    {
        UnitCodeText,
        PilotNameText,
        SpeakerText,
        ScriptText
    }

    private enum Buttons
    {
        UnitButton,
        PilotButton
    }

    private enum Images
    {
        FadeImage
    }

    private enum RawImages
    {
        TargetImage
    }

    private enum GameObjects
    {
        UnitPanel,
        DialoguePanel,
        HPBar,
        ENBar
    }

    void Start()
    {
        Bind<Text>(typeof(Texts));
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));
        Bind<RawImage>(typeof(RawImages));
        Bind<GameObject>(typeof(GameObjects));

        GameManager.Input.MouseAction += MouseAction;
        GameManager.Sound.Play("FirstGundamOST/Track07GallantChar", Define.Sound.Bgm);

        if (GameManager.Data.Common.MainCharacter == Define.Character.BrightNoa || GameManager.Data.Common.MainCharacter == Define.Character.RhysJeon)
            StartDialogue(Define.Dialogue.AmuroRideGundam);
        else
            StartDialogue(Define.Dialogue.MainCharacterRideGundam);
    }

    private void MouseAction(Define.MouseEvent evt)
    {
        if (!DialogueMode)
            return;

        if (evt == Define.MouseEvent.Click)
        {
            //GameManager.Sound.Play("Effect/Flip");
            GameManager.Sound.Play("Effect/Select");
            SetScript();
        }
    }

    public void StartDialogue(Define.Dialogue dialogue)
    {
        DialogueMode = true;
        GetGameObject((int)GameObjects.UnitPanel).SetActive(false);
        GetGameObject((int)GameObjects.DialoguePanel).SetActive(true);

        scripts = GameManager.Script.GetScripts(GameManager.Data.Environment.Language, dialogue);
        SetScript();
    }

    private void SetScript()
    {
        if (scriptNum > scripts.Count - 1)
        {
            DialogueMode = false;
            GetGameObject((int)GameObjects.UnitPanel).SetActive(true);
            GetGameObject((int)GameObjects.DialoguePanel).SetActive(false);
            StartBattle();
            return;
        }

        Script script = scripts[scriptNum];
        string speaker = script.Speaker;

        GetText((int)Texts.SpeakerText).text = speaker.Replace("<MainCharacter>", Util.GetMainCharacterName(GameManager.Data.Environment.Language, GameManager.Data.Common.MainCharacter));
        GetRawImage((int)RawImages.TargetImage).texture = GameManager.Resource.Load<Texture2D>("Characters/" + Util.DefineImageName(speaker));
        GetText((int)Texts.ScriptText).text = script.Content.Replace("<MainCharacter>", Util.GetMainCharacterName(GameManager.Data.Environment.Language, GameManager.Data.Common.MainCharacter));

        scriptNum++;
    }
}
