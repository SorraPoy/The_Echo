using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacDialogueInteract : MonoBehaviour
{
    public GameObject objectToActivate; // Reference to the object with the script to activate
    public float activationRange = 10f; // Range within which the player can activate the object
    public LayerMask layerMask; // Layer mask to determine which objects the player can interact with

    public GameObject PromptToDisable;

    public GameObject SubtitleToShow;

    private bool isPlayerLooking; // Flag to track if the player is looking at the object
    private float lastActivationTime; // Time when the object was last activated

    public AudioSource Dialogue;

    private void Start()
    {

        SubtitleToShow.SetActive(false);

        objectToActivate.SetActive(true);


        objectToActivate.GetComponent<Outline>().enabled = false;

    }

    private void Update()
    {
        // Cast a ray from the camera's position forward
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        // Check if the ray hits something within the activation range and on the specified layer
        if (Physics.Raycast(ray, out hit, activationRange, layerMask))
        {
            if (hit.collider.gameObject == gameObject)
            {
                // If the hit object is the object this script is attached to, set isPlayerLooking to true
                isPlayerLooking = true;
            }
            else
            {
                // If the hit object is not the object this script is attached to, set isPlayerLooking to false
                isPlayerLooking = false;
            }
        }
        else
        {
            // If the ray doesn't hit anything within the activation range, set isPlayerLooking to false
            isPlayerLooking = false;
        }

        if (isPlayerLooking && Input.GetKeyDown(KeyCode.E))
        {
            SubtitleToShow.SetActive(true);
            PromptToDisable.SetActive(false);
            objectToActivate.GetComponent<BoxCollider>().enabled = false;

            Dialogue.Play();
        }


        // If the player is looking at the object, activate it
        if (isPlayerLooking)
        {
            ActivateObject();

        }
        else if (!isPlayerLooking)
        {
            DeactivateObject();
        }
    }

    void ActivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.GetComponent<Outline>().enabled = true;

            // You can add additional activation logic here if needed

            lastActivationTime = Time.time;
        }
    }

    void DeactivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.GetComponent<Outline>().enabled = false;
            lastActivationTime = Time.time;
            // You can add additional activation logic here if needed
        }
    }
}