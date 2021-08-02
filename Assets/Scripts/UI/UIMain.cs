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

        GetButton((int)Buttons.StartButton).gameObject.BindEvent(OnStartButtonClicked);
        GetButton((int)Buttons.LoadButton).gameObject.BindEvent(OnLoadButtonClicked);
        GetButton((int)Buttons.OptionButton).gameObject.BindEvent(OnOptionButtonClicked);
        GetButton((int)Buttons.QuitButton).gameObject.BindEvent(OnQuitButtonClicked);
    }

    private void OnStartButtonClicked(PointerEventData data)
    {
        next = NextScene.Start;
        StartCoroutine(FadeOutCoroutine());
    }

    private void OnLoadButtonClicked(PointerEventData data)
    {
        next = NextScene.Load;
        StartCoroutine(FadeOutCoroutine());
    }

    private void OnOptionButtonClicked(PointerEventData data)
    {
        next = NextScene.Option;
        StartCoroutine(FadeOutCoroutine());
    }

    private void OnQuitButtonClicked(PointerEventData data)
    {
        next = NextScene.Quit;
        StartCoroutine(FadeOutCoroutine());
    }

    private void Update()
    {
        if (fadeOut)
        {
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

    IEnumerator FadeOutCoroutine()
    {
        for (float t = 0.0f; t <= 1.0f; t += 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = Color.Lerp(fadeImage.color, new Color(0, 0, 0, 1), t);

            //if (t <= 0.50f)
            //    bgm.volume = Mathf.Lerp(1.0f, 0.0f, t * 2);

            if (t >= 0.50f)
                fadeOut = true;
        }
    }
}
