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
        private bool fadeOut = false;

        private void Start()
        {
            StartCoroutine(FadeInCoroutine());
        }

        IEnumerator FadeInCoroutine()
        {
            for (float t = 0.0f; t <= 1.0f; t += 0.01f)
            {
                yield return new WaitForSeconds(0.01f);
                fadeImage.color = Color.Lerp(fadeImage.color, new Color(0, 0, 0, 0), t);
            }
        }

        public void ClickEnglish()
        {
            GameManager.Instance.LanguageSetting = GameManager.Language.English;
        }

        public void ClickJapanese()
        {
            GameManager.Instance.LanguageSetting = GameManager.Language.Japanese;
        }

        public void ClickKorean()
        {
            GameManager.Instance.LanguageSetting = GameManager.Language.Korean;
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
