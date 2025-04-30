using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchLightController : MonoBehaviour
{
     public float angleRange = 45f;  // How far the light turns on each axis
    public float speed = 1f;        // Speed of the movement

    public bool rotateX = false;    // Toggle rotation on X axis
    public bool rotateY = true;     // Toggle rotation on Y axis
    public bool rotateZ = false;    // Toggle rotation on Z axis

    private Vector3 startAngles;

    void Start()
    {
        startAngles = transform.eulerAngles;
    }

    void Update()
    {
        float oscillation = Mathf.Sin(Time.time * speed) * angleRange;

        float x = rotateX ? startAngles.x + oscillation : startAngles.x;
        float y = rotateY ? startAngles.y + oscillation : startAngles.y;
        float z = rotateZ ? startAngles.z + oscillation : startAngles.z;

        transform.rotation = Quaternion.Euler(x, y, z);
    }
}
