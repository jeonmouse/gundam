using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Main
{
    public class ButtonClick : MonoBehaviour
    {
        [SerializeField] private Image fadeImage;
        [SerializeField] private AudioSource bgm;

        private enum NextStep
        {
            Start,
            Load,
            Option,
            Quit
        }
        NextStep step = NextStep.Quit;


        private bool fadeOut = false;

        private void Update()
        {
            if (fadeOut)
            {
                switch (step)
                {
                    case NextStep.Start:
                        SceneManager.LoadScene("Selection");
                        break;
                    case NextStep.Load:
                        break;
                    case NextStep.Option:
                        SceneManager.LoadScene("Option");
                        break;
                    case NextStep.Quit:
                        Application.Quit();
                        break;
                }
            }
        }

        public void StartGame()
        {
            step = NextStep.Start;
            StartCoroutine(FadeOutCoroutine());
        }

        IEnumerator FadeOutCoroutine()
        {
            for (float t = 0.0f; t <= 1.0f; t += 0.01f)
            {
                yield return new WaitForSeconds(0.01f);
                fadeImage.color = Color.Lerp(fadeImage.color, new Color(0, 0, 0, 1), t);

                if (t <= 0.50f)
                    bgm.volume = Mathf.Lerp(1.0f, 0.0f, t * 2);

                if (t >= 0.50f)
                    fadeOut = true;
            }
        }

        public void LoadGame()
        {
            step = NextStep.Load;
            StartCoroutine(FadeOutCoroutine());
        }

        public void SetOption()
        {
            step = NextStep.Option;
            StartCoroutine(FadeOutCoroutine());
        }

        public void QuitGame()
        {
            step = NextStep.Quit;
            StartCoroutine(FadeOutCoroutine());
        }
    }
}
