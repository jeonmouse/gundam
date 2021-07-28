using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClick : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;
    [SerializeField] private GameObject[] texts;
    [SerializeField] private GameObject[] panels;
    [SerializeField] private GameObject[] insignia;

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
