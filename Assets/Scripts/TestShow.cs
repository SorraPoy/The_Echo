using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestShow : MonoBehaviour
{


    public TextMeshPro fadeText;

    public float fadeInTime;
    //public TextMeshPro fadeInText;
    public float alphaValueIn;
    public float fadeInPerSecond;

    public float fadeOutTime;
    //public TextMeshPro fadeOutText;
    public float alphaValueOut;
    public float fadeOutPerSecond;


    private bool playerInside = false;

    private void Start()
    {

        //fadeText = fadeText.GetComponent<TextMeshPro>();
        //fadeInPerSecond = 1 / fadeInTime;
        alphaValueIn = 0f;
        alphaValueOut = 0f;


    }

    void Update()
    {
        if (playerInside)
        {
            fadeInTime = 2f;
            fadeInPerSecond = 1f;


            if (fadeInTime > 0 && alphaValueIn >= 0 && alphaValueIn <= 1)
            {

                alphaValueIn += fadeInPerSecond * Time.deltaTime;
                fadeText.color = new Color(fadeText.color.r, fadeText.color.g, fadeText.color.b, alphaValueIn);
                fadeInTime -= Time.deltaTime;

               
            }
        }
        else
        {
            fadeOutTime = 2f;
            fadeOutPerSecond = 1f;

            //fadeText = fadeText.GetComponent<TextMeshPro>();
            //fadeOutPerSecond = 1 / fadeOutTime;
            //alphaValueOut = fadeText.color.a;

            if (fadeOutTime > 0 && alphaValueOut <= 1 && alphaValueOut >= 0)
            {
                alphaValueOut -= fadeOutPerSecond * Time.deltaTime;
                fadeText.color = new Color(fadeText.color.r, fadeText.color.g, fadeText.color.b, alphaValueOut);
                fadeOutTime -= Time.deltaTime;

            }

        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("Player is by the OBJ");
            alphaValueIn = 0f;
            alphaValueOut = 1f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            alphaValueIn = 0;
            alphaValueOut = 1f;
            playerInside = false;
            Debug.Log("The Player has left the OBJ");
        }
    }

}
