using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeAwayScript : MonoBehaviour
{
    public float fadeTime;
    private TextMeshPro fadeAwayText;
    public float alphaValue;
    public float fadeAwayPerSecond;
    public float fadeAwayDelay;

    void Start()
    {
        // Delay the execution of the InitializeFade method by 5 seconds
        Invoke("InitializeFade", fadeAwayDelay);
    }

    // Method to initialize fading after the delay
    void InitializeFade()
    {
        fadeAwayText = GetComponent<TextMeshPro>();
        fadeAwayPerSecond = 1 / fadeTime;
        alphaValue = fadeAwayText.color.a;
    }

    void Update()
    {
        if (fadeTime > 0)
        {
            alphaValue -= fadeAwayPerSecond * Time.deltaTime;
            fadeAwayText.color = new Color(fadeAwayText.color.r, fadeAwayText.color.g, fadeAwayText.color.b, alphaValue);
            fadeTime -= Time.deltaTime;
        }
    }
}