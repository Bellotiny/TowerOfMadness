using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset from the player to position the camera

    public float smoothSpeed = 0.125f; // How smooth the camera movement is
    public Vector3 velocity = Vector3.zero; // To handle the smooth movement

    void Start()
    {
        // You can manually set the offset or use the initial position difference
        if (player != null)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the desired position
            Vector3 desiredPosition = player.position + offset;

            // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

            // Apply the smooth position to the camera
            transform.position = smoothedPosition;

            // Optionally, make the camera look at the player
            transform.LookAt(player);
        }
    }
}
