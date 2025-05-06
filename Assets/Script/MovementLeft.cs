using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLeft : MonoBehaviour
{
    public float moveDistance = 3f;    
    public float moveSpeed = 2f;      
    public float stopDuration = 1f;    

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingRight = false; 
    private bool isStopped = false;
    private float stopTimer = 0f;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.left * moveDistance; 
    }

    void Update()
    {
        if (isStopped)
        {
            stopTimer += Time.deltaTime;
            if (stopTimer >= stopDuration)
            {
                stopTimer = 0f;
                isStopped = false;
                movingRight = !movingRight;

                // Update the next target position based on direction
                if (movingRight)
                    targetPos = startPos;
                else
                    targetPos = startPos + Vector3.left * moveDistance;
            }
            return;
        }

        // Move the cube
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // Stop if reached target
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            isStopped = true;
        }
    }
}
