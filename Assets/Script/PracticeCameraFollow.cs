using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, 2f, -5f);
    public float smoothSpeed = 0.125f;
    public float minDistance = 0.5f;  // How close the camera can get to the player
    public LayerMask collisionLayers; // Layers the camera should collide with

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredCameraPos = player.position + player.TransformDirection(offset);

            // Direction from player to desired camera position
            Vector3 dir = desiredCameraPos - player.position;
            float distance = dir.magnitude;

            // Raycast from player to desired camera position
            if (Physics.Raycast(player.position, dir.normalized, out RaycastHit hit, distance, collisionLayers))
            {
                // Move camera to hit point, slightly forward so it doesn't touch the wall
                desiredCameraPos = hit.point - dir.normalized * minDistance;
            }

            // Smooth follow
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredCameraPos, ref velocity, smoothSpeed);
            transform.position = smoothedPosition;

            // Optional: always look at player
            transform.LookAt(player);
        }
    }
}

