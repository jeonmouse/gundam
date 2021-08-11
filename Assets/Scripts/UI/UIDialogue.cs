using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogue : UIBase
{
    private enum Texts
    {
        SpeakerText,
        ContentText
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

        SetScript();
    }

    private void MouseAction(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.Click)
        {
            if (scriptNum > 1) return;

            scriptNum++;
            SetScript();
        }
    }

    private void SetScript()
    {
        Script script = GameManager.Data.Scripts[scriptNum];
        GetText((int)Texts.SpeakerText).text = script.Speaker.Replace("<MainCharacter>", mainChar);
        GetText((int)Texts.ContentText).text = script.Content.Replace("<MainCharacter>", mainChar);
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
