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
        EnglishText,
        JapaneseText,
        KoreanText
    }

    private enum Images
    {
        FadeImage
    }

    private Image fadeImage;
    private Text[] languageTexts;
    private bool fadeOut;

    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));

        fadeImage = GetImage((int)Images.FadeImage);
        StartCoroutine(FadeInCoroutine());

        languageTexts = GetAll<Text>();

        foreach (Text text in languageTexts)
        {
            if (text.text.Contains(GameManager.Instance.LanguageSetting.ToString()))
                text.color = Color.white;
            else
                text.color = Color.grey;
        }

        GetButton((int)Buttons.EnglishButton).gameObject.BindEvent(OnClickEnglish);
        GetButton((int)Buttons.JapaneseButton).gameObject.BindEvent(OnClickJapanese);
        GetButton((int)Buttons.KoreanButton).gameObject.BindEvent(OnClickKorean);

        GetButton((int)Buttons.ApplyButton).gameObject.BindEvent(OnClickApply);
    }

    private void OnClickEnglish(PointerEventData data)
    {
        SetTextColor("English");
        GameManager.Instance.LanguageSetting = GameManager.Language.English;
    }

    private void OnClickJapanese(PointerEventData data)
    {
        SetTextColor("Japanese");
        GameManager.Instance.LanguageSetting = GameManager.Language.Japanese;
    }

    private void OnClickKorean(PointerEventData data)
    {
        SetTextColor("Korean");
        GameManager.Instance.LanguageSetting = GameManager.Language.Korean;
    }

    private void OnClickApply(PointerEventData data)
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private void SetTextColor(string textName)
    {
        foreach (Text text in languageTexts)
        {
            if (text.text == textName)
                text.color = Color.white;
            else
                text.color = Color.grey;
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
