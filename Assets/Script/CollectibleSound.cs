using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip foodSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("food sounds");
            audioSource.PlayOneShot(foodSound);
        }
    }
}
