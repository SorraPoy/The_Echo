using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationLimit : MonoBehaviour
{
    public float maxRotationAngle = 90f; // Maximum rotation angle allowed


    // Update is called once per frame
    void Update()
    {
        // Get the current rotation of the camera
        Vector3 currentRotation = transform.localRotation.eulerAngles;

        // Clamp the rotation around the y-axis to limit the player's view range
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxRotationAngle, maxRotationAngle);

        // Apply the clamped rotation back to the camera
        transform.localRotation = Quaternion.Euler(currentRotation);
    }
}
