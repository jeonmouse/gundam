using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Main
{
    public class ButtonClick : MonoBehaviour
    {
        [SerializeField] private GameObject fadeImage;
        private Image image;
        private bool fadeOut = false;

        private void Update()
        {
            if (fadeOut)
                SceneManager.LoadScene("Selection");
        }

        public void StartGame()
        {
            //GameManager.Instance.LoadScreenTexture();
            image = fadeImage.GetComponent<Image>();
            StartCoroutine(FadeCoroutine());

            
            //SceneManager.LoadScene("Selection");
        }

        IEnumerator FadeCoroutine()
        {
            for (float t = 0.0f; t <= 1.0f; t += 0.01f)
            {
                yield return new WaitForSeconds(0.01f);
                image.color = Color.Lerp(image.color, new Color(0, 0, 0, 1), t);
            }

            fadeOut = true;
            yield return null;
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
