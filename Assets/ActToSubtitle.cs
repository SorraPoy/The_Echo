using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActToSubtitle : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject SubtitleToShow;

    public void Interact()
    {

        SubtitleToShow.SetActive(false);
    }
}
