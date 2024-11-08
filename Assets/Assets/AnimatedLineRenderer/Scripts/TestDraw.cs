using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.AnimatedLineRenderer
{
    [RequireComponent(typeof(AnimatedLineRenderer))]

    public class TestDraw : MonoBehaviour
    {

        private AnimatedLineRenderer lineRenderer;
        private void Start()
        {
            lineRenderer = GetComponent<AnimatedLineRenderer>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}