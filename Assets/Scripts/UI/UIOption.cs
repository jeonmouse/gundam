using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIOption : UIBase
{
    private enum Buttons
    {
        EnglishButton,
        JapaneseButton,
        KoreanButton,
        ApplyButton
    }

    private enum Texts
    {
        EnglishText = 0,
        JapaneseText,
        KoreanText,
        MaxCount
    }

    private enum Images
    {
        FadeImage
    }

    private Image fadeImage;
    private bool fadeOut;

    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));

        fadeImage = GetImage((int)Images.FadeImage);
        StartCoroutine(FadeInCoroutine());

        SetTextColor(GameManager.Instance.LanguageSetting.ToString());

        GameObject englishButton = GetButton((int)Buttons.EnglishButton).gameObject;
        englishButton.BindEvent(OnHover, Define.UIEvent.Hover);
        englishButton.BindEvent(OnClickEnglish);

        GameObject japaneseButton = GetButton((int)Buttons.JapaneseButton).gameObject;
        japaneseButton.BindEvent(OnHover, Define.UIEvent.Hover);
        japaneseButton.BindEvent(OnClickJapanese);

        GameObject koreanButton = GetButton((int)Buttons.KoreanButton).gameObject;
        koreanButton.BindEvent(OnHover, Define.UIEvent.Hover);
        koreanButton.BindEvent(OnClickKorean);

        GameObject applybutton = GetButton((int)Buttons.ApplyButton).gameObject;
        applybutton.BindEvent(OnHover, Define.UIEvent.Hover);
        applybutton.BindEvent(OnClickApply);
    }

    private void OnHover(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Hover");
    }

    private void OnClickEnglish(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Select");
        SetTextColor("English");
        GameManager.Instance.LanguageSetting = Define.Language.English;
    }

    private void OnClickJapanese(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Select");
        SetTextColor("Japanese");
        GameManager.Instance.LanguageSetting = Define.Language.Japanese;
    }

    private void OnClickKorean(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Select");
        SetTextColor("Korean");
        GameManager.Instance.LanguageSetting = Define.Language.Korean;
    }

    private void OnClickApply(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Select");
        StartCoroutine(FadeOutCoroutine());
    }

    private void SetTextColor(string textName)
    {
        for (int i = 0; i < (int)Texts.MaxCount; i++)
        {
            if (GetText(i).text == textName)
                GetText(i).color = Color.white;
            else
                GetText(i).color = Color.grey;
        }
    }

    IEnumerator FadeInCoroutine()
    {
        for (float t = 0.0f; t <= 1.0f; t += 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = Color.Lerp(fadeImage.color, new Color(0, 0, 0, 0), t);
        }
    }

    IEnumerator FadeOutCoroutine()
    {
        for (float t = 0.0f; t <= 1.0f; t += 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = Color.Lerp(fadeImage.color, new Color(0, 0, 0, 1), t);

            if (t >= 0.50f)
                fadeOut = true;
        }
    }

    void Update()
    {
        if (fadeOut)
            SceneManager.LoadScene("Main");
    }
}
