using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAnimate : MonoBehaviour
{
    public float delayTime = 5f; // Delay time in seconds
    public string animationName; // Name of the animation to play
    public Animator animator; // Reference to the Animator component


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("PlayAnimation", delayTime); // Invoke the PlayAnimation method after the delay
        }
    }

    private void PlayAnimation()
    {
        animator.SetBool(animationName, true);
    }
}