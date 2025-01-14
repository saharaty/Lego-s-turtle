using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class TapToPlaceGecko : MonoBehaviour
{
    [SerializeField] private GameObject geckoPrefab;
    [SerializeField] private GameObject placementIndicatorObject;

    private ARRaycastManager raycastManager;
    private GameObject spawnedGecko;

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // If user taps the screen
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPos = Input.GetTouch(0).position;
            var hits = new List<ARRaycastHit>();
            raycastManager.Raycast(touchPos, hits, TrackableType.PlaneWithinPolygon);

            if (hits.Count > 0)
            {
                Pose hitPose = hits[0].pose;

                // If gecko is not yet placed, instantiate it
                if (spawnedGecko == null)
                {
                    spawnedGecko = Instantiate(geckoPrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    // Or move the existing gecko to a new position
                    spawnedGecko.transform.position = hitPose.position;
                    spawnedGecko.transform.rotation = hitPose.rotation;
                }
            }
        }
    }
}
