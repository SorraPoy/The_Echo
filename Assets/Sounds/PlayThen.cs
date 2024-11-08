using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayThen : MonoBehaviour
{
    public AudioSource FirstSound;
    public AudioSource SecondSound;

    public float delayFirst;
    public float timerForSecond;

    public static PlayThen instance;

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
            Destroy(PlayThen.instance.gameObject);
        }
    }

    private void Start()
    {
        Invoke("PlayFirst", (delayFirst));

        // Play the continuous ambient sound
        FirstSound.Stop();
        SecondSound.Stop();

        // Play the short-duration ambient sound after a delay
        Invoke("PlaySecond", (timerForSecond));
    }

    private void PlayFirst()
    {
        // Play the short-duration ambient sound
        FirstSound.Play();
    }

    private void PlaySecond()
    {
        // Play the short-duration ambient sound
        SecondSound.Play();
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
        FirstSound.Stop();
        SecondSound.Stop();
    }
}
