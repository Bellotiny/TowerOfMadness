using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSound : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true; // Ensure looping
        audioSource.Play(); // Start playing rain sound
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
