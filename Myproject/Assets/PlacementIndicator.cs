using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager raycastManager;

    // Public field for the visual object
    public GameObject visual;

    void Start()
    {
        // Get the ARRaycastManager from the scene
        raycastManager = FindObjectOfType<ARRaycastManager>();

        if (raycastManager == null)
        {
            Debug.LogError("PlacementIndicator: ARRaycastManager not found in the scene! Make sure it's attached to XR Origin.");
        }

        // Ensure the visual is initially hidden
        if (visual != null)
        {
            visual.SetActive(false);
        }
        else
        {
            Debug.LogWarning("PlacementIndicator: No visual object assigned.");
        }
    }

    void Update()
    {
        // Raycast to detect planes in the AR scene
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        var hits = new List<ARRaycastHit>();

        if (raycastManager != null && raycastManager.Raycast(screenCenter, hits, TrackableType.Planes))
        {
            // Get the pose of the detected plane
            Pose hitPose = hits[0].pose;

            // Move the visual to the detected position
            if (visual != null)
            {
                visual.transform.position = hitPose.position;
                visual.transform.rotation = hitPose.rotation;

                // Enable the visual if it’s not already visible
                if (!visual.activeInHierarchy)
                {
                    visual.SetActive(true);
                }
            }
        }
        else
        {
            // Hide the visual if no planes are detected
            if (visual != null && visual.activeInHierarchy)
            {
                visual.SetActive(false);
            }
        }
    }
}
