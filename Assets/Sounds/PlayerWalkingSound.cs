using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingSound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isMoving;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Check if the player is moving
        bool currentlyMoving = IsPlayerMoving();

        // If the moving state has changed
        if (currentlyMoving != isMoving)
        {
            isMoving = currentlyMoving;

            // Play or stop the walking sound based on the moving state
            if (isMoving)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    private bool IsPlayerMoving()
    {
        // Implement your logic to determine if the player is moving
        // This could involve checking player velocity, animation state, input, etc.
        // For example:
        return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
    }
}