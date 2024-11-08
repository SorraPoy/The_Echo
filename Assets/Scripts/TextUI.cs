using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUI : MonoBehaviour
{
    Camera cameraToLookAt;
    Vector3 initialScale;
    public float maxScaleDistance = 10f; // Maximum distance at which object will be scaled to its max size
    public float minScaleDistance = 2f;  // Minimum distance at which object will be scaled to its original size
    public float maxScaleFactor = 2f;    // Maximum scaling factor when object is at maxScaleDistance

    void Start()
    {
        cameraToLookAt = Camera.main;
        initialScale = transform.localScale;
    }

    void LateUpdate()
    {
        transform.LookAt(cameraToLookAt.transform);

        // Calculate the distance between the object and the camera
        float distance = Vector3.Distance(transform.position, cameraToLookAt.transform.position);

        // Calculate the scaling factor based on the distance
        float scaleFactor = Mathf.Clamp01((maxScaleDistance - distance) / (maxScaleDistance - minScaleDistance));
        scaleFactor = Mathf.Lerp(1f, maxScaleFactor, scaleFactor); // Scale factor interpolation

        // Apply the scaling to the object
        transform.localScale = initialScale * scaleFactor;

        // Match the object's rotation to the camera's rotation
        transform.rotation = cameraToLookAt.transform.rotation;
    }
}