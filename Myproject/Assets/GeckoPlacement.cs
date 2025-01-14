using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARPlacementController : MonoBehaviour
{
    public GameObject geckoPrefab; // Assign your Gecko Prefab in the Inspector
    private ARRaycastManager raycastManager;
    private GameObject spawnedGecko;

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // For Editor testing: replace touch input with mouse click
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            Debug.Log("Mouse click detected!");

            // Simulate touch position with mouse position
            Vector2 clickPosition = Input.mousePosition;

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (raycastManager.Raycast(clickPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                if (spawnedGecko == null)
                {
                    spawnedGecko = Instantiate(geckoPrefab, hitPose.position, hitPose.rotation);
                    Debug.Log("Gecko placed at: " + hitPose.position);
                }
                else
                {
                    spawnedGecko.transform.position = hitPose.position;
                    spawnedGecko.transform.rotation = hitPose.rotation;
                    Debug.Log("Gecko moved to: " + hitPose.position);
                }
            }
            else
            {
                Debug.Log("No plane hit detected.");
            }
        }
    }
}
