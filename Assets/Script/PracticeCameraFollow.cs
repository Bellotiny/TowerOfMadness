using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player;
    public float yOffset = 2f;
    public float zOffset = -5f;
    public float smoothSpeed = 0.125f;
    public float minDistance = 0.5f;
    public LayerMask collisionLayers;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (player != null)
        {
            // Only apply offset along the player's forward (Z) and upward (Y) directions
            Vector3 desiredCameraPos = player.position 
                                     + player.up * yOffset 
                                     + player.forward * zOffset;

            Vector3 dir = desiredCameraPos - player.position;
            float distance = dir.magnitude;

            if (Physics.Raycast(player.position, dir.normalized, out RaycastHit hit, distance, collisionLayers))
            {
                desiredCameraPos = hit.point - dir.normalized * minDistance;
            }

            // Smooth position without moving left or right
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredCameraPos, ref velocity, smoothSpeed);
            transform.position = smoothedPosition;

            // Look at the player (optional)
            transform.LookAt(player);
        }
    }
}
