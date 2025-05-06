using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechTrigger : MonoBehaviour
{
    [Header("Dependencies")]
    public TOMTalk talker;
    public Animator spikeDoorAnimator;

    [Header("Settings")]
    public string message = "Be careful";
    public string animationTrigger = "SpikeOpen";
    public string targetTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("" + other.gameObject);
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Triggered by: " + other.name);
            Debug.Log(message);

            if (talker != null && !string.IsNullOrEmpty(message))
                talker.Talk(message);

            if (spikeDoorAnimator != null && !string.IsNullOrEmpty(animationTrigger))
                spikeDoorAnimator.SetTrigger(animationTrigger);
        }
    }
}
