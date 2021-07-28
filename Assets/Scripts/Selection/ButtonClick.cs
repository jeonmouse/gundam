using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Selection
{
    public class ButtonClick : MonoBehaviour
    {
        [SerializeField] private Image fadeImage;

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
    }
}
