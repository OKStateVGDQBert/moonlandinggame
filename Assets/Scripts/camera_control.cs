using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_control : MonoBehaviour {

    // The object for the camera to track
    [SerializeField]private GameObject follow;
    [SerializeField]private float distance;

	// Use this for initialization
	void Start () {
        // Move the camera to face the object at the beginning of the scene
        transform.position = follow.transform.position + Vector3.back * distance;
	}
	
	// Update is called once per frame
	void Update () {
        // Rotate the camera in the up/down direction
        transform.RotateAround(follow.transform.position, transform.up, Input.GetAxis("Mouse X"));
        // Rotate the camera in the left/right direction
        transform.RotateAround(follow.transform.position, transform.right, Input.GetAxis("Mouse Y"));
    }
}
