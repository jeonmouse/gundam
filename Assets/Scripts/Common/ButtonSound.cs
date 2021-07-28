using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private AudioClip hoverClip;
    [SerializeField] private AudioClip selectClip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioSource hover = GetComponent<AudioSource>();
        hover.clip = hoverClip;
        hover.Play();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioSource click = GetComponent<AudioSource>();
        click.clip = selectClip;
        click.Play();
    }
}
