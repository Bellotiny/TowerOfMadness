using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeLightFairy : MonoBehaviour
{
   public Transform player;               // Reference to the player
    public float distanceBack = 2f;        // How far behind the player
    public float distanceRight = 1.5f;     // How far to the right of the player
    public float height = 1.5f;            // Base height above ground
    public float bounceHeight = 0.5f;      // Height of bouncing
    public float bounceSpeed = 3f;         // Speed of bounce
    public float followSmoothness = 5f;    // How smooth the movement is

    private Vector3 targetPosition;

    void Update()
    {
        if (player == null) return;

        // Calculate offset in world space
        Vector3 offset = (-player.forward * distanceBack) + (player.right * distanceRight) + (Vector3.up * height);

        // Add bouncing
        float bounce = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        Vector3 bounceOffset = Vector3.up * bounce;

        // Final target position
        targetPosition = player.position + offset + bounceOffset;

        // Smoothly follow the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSmoothness);
    }
}
