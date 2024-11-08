using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    public AudioSource Dialogue;
    private bool hasSoundPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player and the sound hasn't been played yet
        if (other.CompareTag("Player") && !hasSoundPlayed)
        {
            // Play the dialogue sound
            Dialogue.Play();

            // Set the flag to true to indicate the sound has been played
            hasSoundPlayed = true;
        }
    }
}