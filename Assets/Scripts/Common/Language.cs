using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    [SerializeField] private GameObject[] canvases;

    void Start()
    {
        if (GameManager.Instance == null)
            return;

        string language = GameManager.Instance.LanguageSetting.ToString();

        foreach (GameObject canvas in canvases)
        {
            if (canvas.name.Contains(language))
                canvas.SetActive(true);
            else
                canvas.SetActive(false);
        }
    }
}
