using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSound : MonoBehaviour
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
        float startVolume = AmbientSoundManager.instance.continuousAmbientSource.volume;
        float elapsedTime = 0f;

        while (elapsedTime < fadeOutDuration)
        {
            float newVolume = Mathf.Lerp(startVolume, 0f, elapsedTime / fadeOutDuration);
            AmbientSoundManager.instance.continuousAmbientSource.volume = newVolume;
            AmbientSoundManager.instance.shortDurationAmbientSource.volume = newVolume;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Stop the ambient sounds after the fade out
        AmbientSoundManager.instance.continuousAmbientSource.Stop();
        AmbientSoundManager.instance.shortDurationAmbientSource.Stop();

        Destroy(AmbientSoundManager.instance.gameObject);
    }
}