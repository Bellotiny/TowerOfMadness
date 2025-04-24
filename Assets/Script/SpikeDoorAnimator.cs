using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDoor : MonoBehaviour
{
    public Animator spikeDoorAnimator;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger Spike");
            spikeDoorAnimator.SetTrigger("SpikeOpen");
        }
    }
}
