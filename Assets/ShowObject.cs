using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObject : MonoBehaviour
{
    public GameObject OBJToShow;

    private void Start()
    {
        OBJToShow.SetActive(false);
    }

    void OnTriggerEnter(Collider PlayerEnterArea)
    {
        if (PlayerEnterArea.tag == "Player")
        {
            //Debug.Log("Player is by the OBJ");
            OBJToShow.SetActive(true);
        }
    }

    //void OnTriggerExit(Collider PlayerLeaving)
    //{
    //    if (PlayerLeaving.tag == "Player")
    //    {
    //        Debug.Log("The Player has left the OBJ");
    //        OBJToShow.SetActive(false);
    //    }
    //}


}