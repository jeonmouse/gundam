using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Selection
{
    public class ButtonClick : MonoBehaviour
    {
        [SerializeField] private Image fadeImage;

        [SerializeField] private GameObject[] characters;
        [SerializeField] private GameObject[] texts;
        [SerializeField] private GameObject[] panels;
        [SerializeField] private GameObject[] insignia;

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

        public void ClickCharacterButton(GameObject selection)
        {
            foreach (GameObject character in characters)
            {
                if (character == selection)
                    character.SetActive(true);
                else
                    character.SetActive(false);
            }

            string name = selection.name;

            foreach (GameObject text in texts)
            {
                if (name.Contains(text.name.Replace("Text", "")))
                    text.SetActive(true);
                else
                    text.SetActive(false);
            }

            foreach (GameObject panel in panels)
            {
                if (name.Contains(panel.name.Replace("Panel", "")))
                    panel.SetActive(true);
                else
                    panel.SetActive(false);
            }

            if (name == "RhysJeon" || name == "BrightNoa")
            {
                insignia[0].SetActive(true);
                insignia[1].SetActive(false);
            }
            else
            {
                insignia[0].SetActive(false);
                insignia[1].SetActive(true);
            }
        }
    }
}
