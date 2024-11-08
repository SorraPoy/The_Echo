using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public Animator animator;

    public string levelToLoad;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FadeToNextLevel();
        }
    }


    public void FadeToNextLevel()
    {
        FadeToLevel(levelToLoad);
    }

    public void FadeToLevel(string levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
