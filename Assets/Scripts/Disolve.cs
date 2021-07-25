using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disolve : MonoBehaviour
{
    private RawImage image;

    private float changeSpeed = 2f;

    private void Start()
    {
        image = GetComponent<RawImage>();
        image.texture = GameManager.Instance.ScreenTexture;

        if (image.texture == null)
        {
            gameObject.SetActive(false);
        }

        image.color = Color.black;
    }

    private void Update()
    {
        image.color = Color.Lerp(image.color, new Color(1, 1, 1, 0), changeSpeed * Time.deltaTime);
        if (image.color.a <= 0.01f)
        {
            gameObject.SetActive(false);
        }
    }
}
