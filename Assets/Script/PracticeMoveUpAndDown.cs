using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeMoveUpAndDown : MonoBehaviour
{
     public float moveDistance = 2f; // Distance to move up and down
    public float speed = 2f; // Speed of the movement
    private Vector3 startPos;

    void Start()
    {
        // Store the starting position of the object
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new position based on a sine wave for smooth up and down movement
        float newY = Mathf.Sin(Time.time * speed) * moveDistance + startPos.y;

        // Update the object's position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

   
}
