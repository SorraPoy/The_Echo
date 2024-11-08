using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayThen : MonoBehaviour
{
    public float fadeOutDuration = 2f; // Duration in seconds for the fade out

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            // Fade out the ambient sounds
            StartCoroutine(FadeOutAmbientSounds());
        }
    }

    private IEnumerator FadeOutAmbientSounds()
    {
        float startVolume = PlayThen.instance.FirstSound.volume;
        float elapsedTime = 0f;

        while (elapsedTime < fadeOutDuration)
        {
            float newVolume = Mathf.Lerp(startVolume, 0f, elapsedTime / fadeOutDuration);
            PlayThen.instance.FirstSound.volume = newVolume;
            PlayThen.instance.SecondSound.volume = newVolume;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Stop the ambient sounds after the fade out
        PlayThen.instance.FirstSound.Stop();
        PlayThen.instance.SecondSound.Stop();

        Destroy(PlayThen.instance.gameObject);
    }
}