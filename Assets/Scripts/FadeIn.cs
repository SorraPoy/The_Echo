using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float fadeTime;
    private TextMeshPro fadeInText;
    public float alphaValue;
    public float fadeInPerSecond;

    void Start()
    {
        alphaValue = 0f;
        fadeInText = GetComponent<TextMeshPro>();
        fadeInPerSecond = 1 / fadeTime;
        alphaValue = fadeInText.color.a;
    }


    void Update()
    {
        if (fadeTime > 0)
        {
            alphaValue += fadeInPerSecond * Time.deltaTime;
            fadeInText.color = new Color(fadeInText.color.r, fadeInText.color.g, fadeInText.color.b, alphaValue);
            fadeTime -= Time.deltaTime;
        }
    }
}