using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Option
{
    public class ButtonClick : MonoBehaviour
    {
        [SerializeField] private Image fadeImage;
        [SerializeField] private Text[] langTexts;
        private bool fadeOut = false;

        private void Start()
        {
            StartCoroutine(FadeInCoroutine());

            foreach (Text text in langTexts)
            {
                if (text.text.Contains(GameManager.Instance.LanguageSetting.ToString()))
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

        public void ClickLanguage(Text selectedText)
        {
            foreach (Text text in langTexts)
            {
                if (text == selectedText)
                    text.color = Color.white;
                else
                    text.color = Color.grey;
            }

            if (selectedText.text.Contains("English"))
                GameManager.Instance.LanguageSetting = GameManager.Language.English;
            else if (selectedText.text.Contains("Japanese"))
                GameManager.Instance.LanguageSetting = GameManager.Language.Japanese;
            else
                GameManager.Instance.LanguageSetting = GameManager.Language.Korean;

        }

        public void ClickJapanese()
        {
        }

        public void ClickKorean()
        {
        }

        private void Update()
        {
            if (fadeOut)
                SceneManager.LoadScene("Main");
        }

        public void ClickApply()
        {
            StartCoroutine(FadeOutCoroutine());
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
    }
}
