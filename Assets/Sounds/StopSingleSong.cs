using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSingleSong : MonoBehaviour
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
        float startVolume = SingleSong.instance.Song.volume;
        float elapsedTime = 0f;

        while (elapsedTime < fadeOutDuration)
        {
            float newVolume = Mathf.Lerp(startVolume, 0f, elapsedTime / fadeOutDuration);
            SingleSong.instance.Song.volume = newVolume;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Stop the ambient sounds after the fade out
        SingleSong.instance.Song.Stop();

        // Destroy the GameObject after the fade out is complete
        Destroy(SingleSong.instance.gameObject);

    }
}