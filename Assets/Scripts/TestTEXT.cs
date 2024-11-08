using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestTEXT : MonoBehaviour
{

    [SerializeField] TextMeshPro _textMeshPro;

    public string[] stringArray;

    [SerializeField] float timeBtwnChars;
    [SerializeField] float timeBtwnWords;

    int i = 0;



    TMP_Text textMesh;

    Mesh mesh;

    Vector3[] vertices;

    List<int> wordIndexes;
    List<int> wordLengths;

    public float fadeInTime;
    private TextMeshPro fadeInText;
    public float alphaValueIn;
    public float fadeInPerSecond;
    public float fadeInDelay;

    public float fadeOutTime;
    private TextMeshPro fadeOutText;
    public float alphaValueOut;
    public float fadeOutPerSecond;
    public float fadeOutDelay;

    // Start is called before the first frame update
    void Start()
    {

        fadeInText = GetComponent<TextMeshPro>();
        fadeInPerSecond = 1 / fadeInTime;
        alphaValueIn = fadeInText.color.a;

        textMesh = GetComponent<TMP_Text>();

        wordIndexes = new List<int> { 0 };
        wordLengths = new List<int>();

        string s = textMesh.text;
        for (int index = s.IndexOf(' '); index > -1; index = s.IndexOf(' ', index + 1))
        {
            wordLengths.Add(index - wordIndexes[wordIndexes.Count - 1]);
            wordIndexes.Add(index + 1);
        }
        wordLengths.Add(s.Length - wordIndexes[wordIndexes.Count - 1]);


    }



    // Update is called once per frame
    void Update()
    {
        Invoke("EndCheck", fadeInDelay);

        if (fadeInTime > 0)
        {
            Invoke("FadeInFunction", fadeInDelay);

        }
        if (fadeOutTime > 0)
        {
            Invoke("FadeOutFunction", fadeOutDelay);
        }

        WobbleEffect();

    }


    public void EndCheck()
    {
        if (i <= stringArray.Length - 1)
        {
            WobbleEffect();

            _textMeshPro.text = stringArray[i];
            StartCoroutine(TextVisible());
            Debug.Log("Start Writing" + "// " + _textMeshPro.text);
        }
    }

    private IEnumerator TextVisible()
    {
        WobbleEffect();



        _textMeshPro.ForceMeshUpdate();
        int totalVisibleCharacters = _textMeshPro.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            WobbleEffect();

            int visibleCount = counter % (totalVisibleCharacters + 1);
            _textMeshPro.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
            {
                WobbleEffect();

                i += 1;
                Invoke("EndCheck", timeBtwnWords);
                break;
            }
            WobbleEffect();
            counter += 1;
            yield return new WaitForSeconds(timeBtwnChars);


        }
    }



    public void FadeInFunction()
    {



        if (fadeOutTime > 0 && alphaValueIn <= 1)
        {
            alphaValueIn += fadeInPerSecond * Time.deltaTime;
            fadeInText.color = new Color(fadeInText.color.r, fadeInText.color.g, fadeInText.color.b, alphaValueIn);
            fadeInTime -= Time.deltaTime;
        }

        WobbleEffect();

    }


    public void FadeOutFunction()
    {
        fadeOutText = GetComponent<TextMeshPro>();
        fadeOutPerSecond = 1 / fadeOutTime;
        alphaValueOut = fadeOutText.color.a;

        if (fadeOutTime > 0)
        {
            alphaValueOut -= fadeOutPerSecond * Time.deltaTime;
            fadeOutText.color = new Color(fadeOutText.color.r, fadeOutText.color.g, fadeOutText.color.b, alphaValueOut);
            fadeOutTime -= Time.deltaTime;
        }

        WobbleEffect();

    }

    public void WobbleEffect()
    {


        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;


        for (int w = 0; w < wordIndexes.Count; w++)
        {
            int wordIndex = wordIndexes[w];
            Vector3 offset = Wobble(Time.time + w);

            for (int i = 0; i < wordLengths[w]; i++)
            {
                TMP_CharacterInfo c = textMesh.textInfo.characterInfo[wordIndex + i];

                int index = c.vertexIndex;


                vertices[index] += offset;
                vertices[index + 1] += offset;
                vertices[index + 2] += offset;
                vertices[index + 3] += offset;


            }
        }



        mesh.vertices = vertices;
    }

    Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time * 0.5f), Mathf.Cos(time * 0.5f));
    }



}

