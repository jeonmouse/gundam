using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TitleSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioClip Clip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioSource hover = GetComponent<AudioSource>();
        hover.Play();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioSource click = GetComponent<AudioSource>();
        click.clip = Clip;
        click.Play();
    }
}
