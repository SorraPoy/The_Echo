using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    public GameObject OBJToHide;

    private void Start()
    {
        OBJToHide.SetActive(true);
    }

    void OnTriggerEnter(Collider PlayerEnterArea)
    {
        if (PlayerEnterArea.tag == "Player")
        {
            //Debug.Log("Player is by the OBJ");
            OBJToHide.SetActive(false);
        }
    }

    //void OnTriggerExit(Collider PlayerLeaving)
    //{
    //    if (PlayerLeaving.tag == "Player")
    //    {
    //        Debug.Log("The Player has left the OBJ");
    //        OBJToHide.SetActive(false);
    //    }
    //}


}
