using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIDialogue : UIBase
{
    private enum Texts
    {
        SpeakerText,
        ContentText,
        SelectText2_1,
        SelectText2_2,
        MaxCount
    }

    private enum Buttons
    {
        SelectButton2_1,
        SelectButton2_2
    }

    private enum Images
    {
        FadeImage
    }

    private enum RawImages
    {
        BackgroundImage,
        LeftImage,
        RightImage
    }

    private enum GameObjects
    {
        SelectPanel2
    }

    private List<Script> scripts;
    private Image fadeImage;
    private Define.DialogueEvent evt;
    private bool fadeOut = false;
    private string mainChar;
    private int scriptNum = 0;
    private bool eventOccurred = false;
    private bool buttonClicked = false;
    private int lastId = -1;
    private int joinId = -1;

    private void Start()
    {
        Bind<Text>(typeof(Texts));
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));
        Bind<RawImage>(typeof(RawImages));
        Bind<GameObject>(typeof(GameObjects));

        GameManager.Input.MouseAction += MouseAction;

        fadeImage = GetImage((int)Images.FadeImage);
        StartCoroutine(FadeInCoroutine());

        mainChar = Util.GetMainCharacterName(GameManager.Data.Environment.Language,
            GameManager.Data.Common.MainCharacter);

        InitScene();

        if (GameManager.Data.Environment.Language == Define.Language.Japanese) SetJapaneseFont();

        GameObject select2_1Button = GetButton((int)Buttons.SelectButton2_1).gameObject;
        select2_1Button.BindEvent(OnHover, Define.UIEvent.Hover);
        select2_1Button.BindEvent(OnClickButton2_1);

        GameObject select2_2Button = GetButton((int)Buttons.SelectButton2_2).gameObject;
        select2_2Button.BindEvent(OnHover, Define.UIEvent.Hover);
        select2_2Button.BindEvent(OnClickButton2_2);

        GetGameObject((int)GameObjects.SelectPanel2).SetActive(false);
        SetScript();
    }

    private void InitScene()
    {
        GameManager.Data.Common.Scene = GameManager.Data.Common.NextScene;

        switch (GameManager.Data.Common.Scene)
        {
            case Define.Scene.TemRayRoom:
                GetRawImage((int)RawImages.BackgroundImage).texture = GameManager.Resource.Load<Texture2D>("Backgrounds/TemRayRoom");
                GetRawImage((int)RawImages.LeftImage).texture = GameManager.Resource.Load<Texture2D>("Characters/TemRay");
                GameManager.Data.Common.NextScene = Define.Scene.GundamRising;
                break;
            case Define.Scene.GundamFactory:
                GetRawImage((int)RawImages.BackgroundImage).texture = GameManager.Resource.Load<Texture2D>("Backgrounds/GundamFactory");
                GetRawImage((int)RawImages.LeftImage).texture = GameManager.Resource.Load<Texture2D>("Characters/FarrellIha");
                GameManager.Data.Common.NextScene = Define.Scene.GundamRising;
                break;
        }

        scripts = GameManager.Script.GetScripts(GameManager.Data.Environment.Language, GameManager.Data.Common.Scene);
    }

    private void OnHover(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Hover");
    }

    private void OnClickButton2_1(PointerEventData data)
    {
        Event.GetDialogueEventValues(evt, 1, out int nextId, out int lastId, out int joinId);
        GameManager.Data.SetEventFlag(evt, 1);
        RestartDialogue(nextId, lastId, joinId);
    }

    private void OnClickButton2_2(PointerEventData data)
    {
        Event.GetDialogueEventValues(evt, 2, out int nextId, out int lastId, out int joinId);
        GameManager.Data.SetEventFlag(evt, 2);
        RestartDialogue(nextId, lastId, joinId);
    }

    private void RestartDialogue(int nextId, int lastId, int joinId)
    {
        GameManager.Sound.Play("Effect/Select");
        scriptNum = nextId;
        this.lastId = lastId;
        this.joinId = joinId;
        eventOccurred = false;
        buttonClicked = true;
        GetText((int)Texts.ContentText).gameObject.SetActive(true);
        GetGameObject((int)GameObjects.SelectPanel2).SetActive(false);
        SetScript();
    }

    private void MouseAction(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.Click && !eventOccurred && !buttonClicked)
        {
            //GameManager.Sound.Play("Effect/Flip");
            GameManager.Sound.Play("Effect/Select");
            SetScript();
        }

        if (evt == Define.MouseEvent.Click && buttonClicked)
        {
            buttonClicked = false;
        }
    }

    private void SetJapaneseFont()
    {
        for (int i = 0; i < (int)Texts.MaxCount; i++)
        {
            GetText(i).font = GameManager.Resource.Load<Font>("Fonts/PixelMplus10");
            if (GetText(i).fontSize == 20)
                GetText(i).fontSize = 15;
        }
    }

    private void SetScript()
    {
        if (scriptNum > scripts.Count - 1)
        {
            StartCoroutine(FadeOutCoroutine());
            return;
        }

        Script script = scripts[scriptNum];

        Script.Position position = script.Place;
        string speaker = script.Speaker;

        if (position == Script.Position.Left)
            GetRawImage((int)RawImages.LeftImage).texture = GameManager.Resource.Load<Texture2D>("Characters/" + Util.DefineImageName(speaker));
        else if (position == Script.Position.Right)
            GetRawImage((int)RawImages.RightImage).texture = GameManager.Resource.Load<Texture2D>("Characters/" + Util.DefineImageName(speaker));

        if (script.Type == Script.DialogType.Select2)
        {
            GetText((int)Texts.ContentText).gameObject.SetActive(false);
            GetGameObject((int)GameObjects.SelectPanel2).SetActive(true);

            string[] contents = script.Content.Split('/');

            GetText((int)Texts.SpeakerText).text = mainChar;
            GetText((int)Texts.SelectText2_1).text = contents[0];
            GetText((int)Texts.SelectText2_2).text = contents[1];
            evt = script.Event;
            eventOccurred = true;
        }
        else
        {
            speaker = speaker.Replace("<MainCharacter>", mainChar);
            string content = script.Content.Replace("<MainCharacter>", mainChar);

            GetText((int)Texts.SpeakerText).text = speaker;
            GetText((int)Texts.ContentText).text = content;

            if (scriptNum == lastId)
                scriptNum = joinId;
            else
                scriptNum++;
        }
    }

    void Update()
    {
        if (fadeOut)
        {
            GameManager.Clear();
            SceneManager.LoadScene("Battle");
        }
    }

    private IEnumerator FadeInCoroutine()
    {
        for (float t = 0.0f; t <= 1.0f; t += 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = Color.Lerp(fadeImage.color, new Color(0, 0, 0, 0), t);
        }
    }

    private IEnumerator FadeOutCoroutine()
    {
        for (float t = 0.0f; t <= 1.0f; t += 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = Color.Lerp(fadeImage.color, new Color(0, 0, 0, 1), t);

            if (t >= 0.50f)
                fadeOut = true;
        }
    }
}
