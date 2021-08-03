using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMain : UIBase
{
    private enum NextScene
    {
        Start,
        Load,
        Option,
        Quit
    }
    NextScene next = NextScene.Quit;

    private enum Buttons
    {
        StartButton,
        LoadButton,
        OptionButton,
        QuitButton
    }

    private enum Images
    {
        FadeImage
    }

    private Image fadeImage;
    private bool fadeOut = false;

    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));

        fadeImage = GetImage((int)Images.FadeImage);
        StartCoroutine(FadeInCoroutine());

        GameObject startButton = GetButton((int)Buttons.StartButton).gameObject;
        startButton.BindEvent(OnHover, Define.UIEvent.Hover);
        startButton.BindEvent(OnClickStart);

        GameObject loadButton = GetButton((int)Buttons.LoadButton).gameObject;
        loadButton.BindEvent(OnHover, Define.UIEvent.Hover);
        loadButton.BindEvent(OnClickLoad);

        GameObject optionButton = GetButton((int)Buttons.OptionButton).gameObject;
        optionButton.BindEvent(OnHover, Define.UIEvent.Hover);
        optionButton.BindEvent(OnClickOption);

        GameObject quitButton = GetButton((int)Buttons.QuitButton).gameObject;
        quitButton.BindEvent(OnHover, Define.UIEvent.Hover);
        quitButton.BindEvent(OnClickQuit);

        GameManager.Sound.Play("FirstGundamOST/Track03FromSleep", Define.Sound.Bgm);
    }

    private void OnHover(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Hover");
    }

    private void OnClickStart(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Select");
        next = NextScene.Start;
        StartCoroutine(FadeOutCoroutine());
    }

    private void OnClickLoad(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Select");
        next = NextScene.Load;
        StartCoroutine(FadeOutCoroutine());
    }

    private void OnClickOption(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Select");
        next = NextScene.Option;
        StartCoroutine(FadeOutCoroutine());
    }

    private void OnClickQuit(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Select");
        next = NextScene.Quit;
        StartCoroutine(FadeOutCoroutine());
    }

    private void Update()
    {
        if (fadeOut)
        {
            GameManager.Clear();

            switch (next)
            {
                case NextScene.Start:
                    SceneManager.LoadScene("Selection");
                    break;
                case NextScene.Load:
                    break;
                case NextScene.Option:
                    SceneManager.LoadScene("Option");
                    break;
                case NextScene.Quit:
                    Application.Quit();
                    break;
            }
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

            if (t <= 0.50f)
                GameManager.Sound.SetSoundVolume(Mathf.Lerp(1.0f, 0.0f, t * 2));

            if (t >= 0.50f)
                fadeOut = true;
        }
    }
}
