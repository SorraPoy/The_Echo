using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneTrueFalse : MonoBehaviour
{
    public TrueFalse truefalse;
    public string trueSceneName;
    public string falseSceneName;

    private void Start()
    {
        CheckObjectValue();
    }

    private void CheckObjectValue()
    {
        if (truefalse.dad && truefalse.bird && truefalse.mom && truefalse.family)
        {
            // Load the 'true' scene
            SceneManager.LoadScene(trueSceneName);
        }
        else
        {
            // Load the 'false' scene
            SceneManager.LoadScene(falseSceneName);
        }
    }
}
