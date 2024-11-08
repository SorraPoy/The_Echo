using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptSubtitle : MonoBehaviour
{
    public GameObject SubtitleOBJ;



    private void Start()
    {
        SubtitleOBJ.SetActive(false);
    }

    void OnTriggerEnter(Collider TheThingEnteringTheTrigger)
    {
        if (TheThingEnteringTheTrigger.tag == "Player")
        {
            //Debug.Log("Player is by the OBJ");
            SubtitleOBJ.SetActive(true);
        }
    }

    //void OnTriggerExit(Collider TheThingLeaving)
    //{
    //    if (TheThingLeaving.tag == "Player")
    //    {
    //        Debug.Log("The Player has left the OBJ");
    //        SubtitleOBJ.SetActive(false);
    //    }
    //}


}
