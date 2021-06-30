using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TitleSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip Clip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioSource hover = GetComponent<AudioSource>();
        hover.Play();
    }

    public void Click()
    {
        AudioSource click = GetComponent<AudioSource>();
        click.clip = Clip;
        click.Play();
    }
}
