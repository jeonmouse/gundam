using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private AudioClip clip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioSource hover = GetComponent<AudioSource>();
        hover.Play();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioSource click = GetComponent<AudioSource>();
        click.clip = clip;
        click.Play();
    }
}
