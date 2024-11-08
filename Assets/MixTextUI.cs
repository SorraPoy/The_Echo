using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MixTextUI : MonoBehaviour
{
    TMP_Text textMesh;

    List<int> wordIndexes;
    List<int> wordLengths;

    public float fadeInTime;
    public float alphaValueIn;
    public float fadeInPerSecond;
    public float fadeInDelay;

    public float fadeOutTime;
    public float alphaValueOut;
    public float fadeOutPerSecond;
    public float fadeOutDelay;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
        fadeInPerSecond = 1 / fadeInTime;
        alphaValueIn = textMesh.alpha;

        wordIndexes = new List<int> { 0 };
        wordLengths = new List<int>();

        string s = textMesh.text;
        for (int index = s.IndexOf(' '); index > -1; index = s.IndexOf(' ', index + 1))
        {
            wordLengths.Add(index - wordIndexes[wordIndexes.Count - 1]);
            wordIndexes.Add(index + 1);
        }
        wordLengths.Add(s.Length - wordIndexes[wordIndexes.Count - 1]);

        Invoke("InitializeFadeOut", fadeOutDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeInTime > 0)
        {
            Invoke("FadeInFunction", fadeInDelay);
        }
        if (fadeOutTime > 0)
        {
            Invoke("FadeOutFunction", fadeOutDelay);
        }

        textMesh.ForceMeshUpdate();
        TMP_TextInfo textInfo = textMesh.textInfo;
        Vector3[] vertices = textMesh.mesh.vertices;

        for (int w = 0; w < wordIndexes.Count; w++)
        {
            int wordIndex = wordIndexes[w];
            Vector3 offset = Wobble(Time.time + w);

            for (int i = 0; i < wordLengths[w]; i++)
            {
                TMP_CharacterInfo c = textInfo.characterInfo[wordIndex + i];

                int index = c.vertexIndex;

                vertices[index] += offset;
                vertices[index + 1] += offset;
                vertices[index + 2] += offset;
                vertices[index + 3] += offset;
            }
        }

        textMesh.mesh.vertices = vertices;
    }

    void InitializeFadeOut()
    {
        fadeOutPerSecond = 1 / fadeOutTime;
        alphaValueOut = textMesh.alpha;
    }

    public void FadeInFunction()
    {
        if (fadeOutTime > 0 && alphaValueIn <= 1)
        {
            alphaValueIn += fadeInPerSecond * Time.deltaTime;
            textMesh.alpha = alphaValueIn;
            fadeInTime -= Time.deltaTime;
        }

        // Update mesh and apply wobble effect
        textMesh.ForceMeshUpdate();
        TMP_TextInfo textInfo = textMesh.textInfo;
        Vector3[] vertices = textMesh.mesh.vertices;

        for (int w = 0; w < wordIndexes.Count; w++)
        {
            int wordIndex = wordIndexes[w];
            Vector3 offset = Wobble(Time.time + w);

            for (int i = 0; i < wordLengths[w]; i++)
            {
                TMP_CharacterInfo c = textInfo.characterInfo[wordIndex + i];

                int index = c.vertexIndex;

                vertices[index] += offset;
                vertices[index + 1] += offset;
                vertices[index + 2] += offset;
                vertices[index + 3] += offset;
            }
        }

        textMesh.mesh.vertices = vertices;
    }

    public void FadeOutFunction()
    {
        if (fadeOutTime > 0)
        {
            alphaValueOut -= fadeOutPerSecond * Time.deltaTime;
            textMesh.alpha = alphaValueOut;
            fadeOutTime -= Time.deltaTime;
        }

        // Update mesh and apply wobble effect
        textMesh.ForceMeshUpdate();
        TMP_TextInfo textInfo = textMesh.textInfo;
        Vector3[] vertices = textMesh.mesh.vertices;

        for (int w = 0; w < wordIndexes.Count; w++)
        {
            int wordIndex = wordIndexes[w];
            Vector3 offset = Wobble(Time.time + w);

            for (int i = 0; i < wordLengths[w]; i++)
            {
                TMP_CharacterInfo c = textInfo.characterInfo[wordIndex + i];

                int index = c.vertexIndex;

                vertices[index] += offset;
                vertices[index + 1] += offset;
                vertices[index + 2] += offset;
                vertices[index + 3] += offset;
            }
        }

        textMesh.mesh.vertices = vertices;
    }

    Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time * 0.2f), Mathf.Cos(time * 0.2f));
    }
}