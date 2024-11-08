using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayPlay : MonoBehaviour
{
    public AudioSource Sound;
    public float delayTime;


    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            // Stop the ambient sounds
            Invoke("PlaySound", (delayTime));
        }
    }

    private void PlaySound()
    {
        // Play the short-duration ambient sound
        Sound.Play();
    }
}
