using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScarySound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip fogHorn;
    private bool playedAlready;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playedAlready = false;
    }

    // Update is called once per frame
     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playedAlready)
        {
            Debug.Log("fog horn sounds");
            playedAlready = true;
            audioSource.PlayOneShot(fogHorn);
        }
    }
}
