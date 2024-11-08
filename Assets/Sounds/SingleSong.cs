using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleSong : MonoBehaviour
{
    public AudioSource Song;

    public float delayTime;

    public static SingleSong instance;

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
            Destroy(SingleSong.instance.gameObject);
        }
    }

    private void Start()
    {
        Invoke("PlayFirst", (delayTime));

        // Play the continuous ambient sound
        Song.Stop();

    }

    private void PlayFirst()
    {
        // Play the short-duration ambient sound
        Song.Play();
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
        Song.Stop();
    }
}
