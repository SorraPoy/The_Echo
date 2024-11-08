using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmbientSoundManager : MonoBehaviour
{
    public AudioSource continuousAmbientSource;
    public AudioSource shortDurationAmbientSource;

    public static AmbientSoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(AmbientSoundManager.instance.gameObject);
        }
    }

    private void Start()
    {
        // Play the continuous ambient sound
        continuousAmbientSource.Play();
        shortDurationAmbientSource.Stop();

        // Play the short-duration ambient sound after a delay
        Invoke("PlayShortDurationAmbient", 5f);
    }

    private void PlayShortDurationAmbient()
    {
        // Play the short-duration ambient sound
        shortDurationAmbientSource.Play();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Add any additional logic here to handle scene changes, if needed
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void StopAllAmbientSounds()
    {
        continuousAmbientSource.Stop();
        shortDurationAmbientSource.Stop();
    }
}