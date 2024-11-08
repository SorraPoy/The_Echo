#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuitGamePrompt();
        }
    }


    public void QuitGamePrompt()
    {
        // Display a confirmation dialog
        if (Application.isEditor)
        {
            // If the game is running in the Unity Editor
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            // If the game is running as a standalone build
#if UNITY_STANDALONE
            Application.Quit();
#endif

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
#endif