using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeScriptPlayer : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the movement

    // Update is called once per frame
    void Update()
    {
        // Get input from the player (WASD or Arrow keys)
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys

        // Create a movement vector
        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;

        // Move the capsule
        transform.Translate(movement);
    }
}
