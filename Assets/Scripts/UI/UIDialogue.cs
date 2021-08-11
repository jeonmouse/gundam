using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogue : UIBase
{
    private enum Texts
    {
        SpeakerText,
        ContentText,
        MaxCount
    }

    private enum Images
    {
        FadeImage
    }

    private enum RawImages
    {
        LeftImage,
        RightImage
    }

    private Image fadeImage;
    private bool fadeOut = false;
    private string mainChar;
    private int scriptNum = 0;

    private void Start()
    {
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<RawImage>(typeof(RawImages));

        GameManager.Input.MouseAction += MouseAction;

        fadeImage = GetImage((int)Images.FadeImage);
        StartCoroutine(FadeInCoroutine());

        mainChar = Util.GetMainCharacterName(GameManager.Data.Environment.Language,
            GameManager.Data.Common.MainCharacter);

        if (GameManager.Data.Common.MainCharacter == Define.MainCharacter.Bright)
            GetRawImage((int)RawImages.RightImage).texture = GameManager.Resource.Load<Texture2D>("Characters/BrightNoa");
        else if (GameManager.Data.Common.MainCharacter == Define.MainCharacter.Rhys)
            GetRawImage((int)RawImages.RightImage).texture = GameManager.Resource.Load<Texture2D>("Characters/RhysJeon");
        else if (GameManager.Data.Common.MainCharacter == Define.MainCharacter.Dominick)
            GetRawImage((int)RawImages.RightImage).texture = GameManager.Resource.Load<Texture2D>("Characters/DominickWilliam");
        else if (GameManager.Data.Common.MainCharacter == Define.MainCharacter.Leon)
            GetRawImage((int)RawImages.RightImage).texture = GameManager.Resource.Load<Texture2D>("Characters/LeonMarcenas");

        if (GameManager.Data.Environment.Language == Define.Language.Japanese) SetJapaneseFont();

        SetScript();
    }

    private void MouseAction(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.Click)
        {
            scriptNum++;
            SetScript();
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
        if (scriptNum > GameManager.Data.Scripts.Count - 1) return;

        Script script = GameManager.Data.Scripts[scriptNum];
        string speaker = script.Speaker.Replace("<MainCharacter>", mainChar);
        string content = script.Content.Replace("<MainCharacter>", mainChar);

        if (content.Contains("/"))
        {
            string[] strArray = content.Split('/');
            if (GameManager.Data.Common.MainCharacter == Define.MainCharacter.Bright)
                content = strArray[0];
            else if (GameManager.Data.Common.MainCharacter == Define.MainCharacter.Rhys)
                content = strArray[1];
            if (GameManager.Data.Common.MainCharacter == Define.MainCharacter.Dominick)
                content = strArray[2];
            if (GameManager.Data.Common.MainCharacter == Define.MainCharacter.Leon)
                content = strArray[3];
        }

        GetText((int)Texts.SpeakerText).text = speaker;
        GetText((int)Texts.ContentText).text = content;
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
