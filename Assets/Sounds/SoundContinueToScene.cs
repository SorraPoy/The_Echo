using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundContinueToScene : MonoBehaviour
{
    public AudioSource FXSound;

    public static SoundContinueToScene instance;

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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            // Stop the ambient sounds
            FXSound.Play();
        }
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Add any additional logic here to handle scene changes, if needed
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}