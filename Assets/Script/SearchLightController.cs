using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchLightController : MonoBehaviour
{
     public float angleRange = 45f;      // How far the light turns left and right
    public float speed = 1f;            // Speed of the movement

    private float startAngle;

    void Start()
    {
        startAngle = transform.eulerAngles.y;
    }

    void Update()
    {
        float angle = startAngle + Mathf.Sin(Time.time * speed) * angleRange;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
