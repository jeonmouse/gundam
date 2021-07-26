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
        private bool fadeOut = false;

        [SerializeField] private AudioSource bgm;

        private void Update()
        {
            if (fadeOut)
                SceneManager.LoadScene("Selection");
        }

        public void StartGame()
        {
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
            Debug.Log("load");
        }

        public void SetOption()
        {
            Debug.Log("option");
        }

        public void QuitGame()
        {
            Debug.Log("quit");
            Application.Quit();
        }
    }
}
