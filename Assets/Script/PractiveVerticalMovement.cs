using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PractiveVerticalMovement : MonoBehaviour
{
    
    public float moveDistance = 5f;       // How far the platform moves up and down
    public float moveSpeed = 2f;          // Speed of movement
    private Vector3 startPos;             // Starting position
    private bool goingUp = true;          // Direction toggle

    void Start()
    {
        // Record the starting position
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new position
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        transform.position = new Vector3(startPos.x, startPos.y + offset, startPos.z);
    }
}
