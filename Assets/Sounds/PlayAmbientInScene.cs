using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAmbientInScene : MonoBehaviour
{
    public AudioSource AmbientSound;


    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            // Stop the ambient sounds
            AmbientSound.Play();
        }
    }
}
