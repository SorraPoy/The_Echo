using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberGenerator : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject Block;
    private bool blockup;

    public void Interact()
    {

        blockup = !blockup;
        Block.GetComponent<Animator>().SetBool("IsOpen", blockup);
    }
}
