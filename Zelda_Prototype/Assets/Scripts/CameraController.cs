using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform objectToFollow;
    public Tilemap theMap;
    public Vector3 bottomLeftLimit;
    public Vector3 topRightLimit;

    // Start is called before the first frame update
    void Start()
    {
        objectToFollow = FindObjectOfType<PlayerController>().transform;
        bottomLeftLimit = theMap.localBounds.min;
        topRightLimit = theMap.localBounds.max;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(objectToFollow == null)
        {
            objectToFollow = FindObjectOfType<PlayerController>().transform;
        }
        transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, transform.position.z);

        // Keep cam inside the bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
}
