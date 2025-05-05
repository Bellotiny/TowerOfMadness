using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticePlatformRightAndLeft : MonoBehaviour
{
    public float moveDistance = 5f; 
    public float speed = 2f; 

    private Vector3 startPosition;

    void Start()
    {
        // Store the initial position of the object
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position using Mathf.Sin to create smooth oscillation
        float newX = Mathf.Sin(Time.time * speed) * moveDistance + startPosition.x;

        // Update the object's position
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    } 
    
}
