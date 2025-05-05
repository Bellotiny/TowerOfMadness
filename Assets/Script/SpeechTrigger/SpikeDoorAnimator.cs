using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDoor : MonoBehaviour
{
    public TOMTalk talker;
    public Animator spikeDoorAnimator;
    //public float pushForce = 5f;

     void Start()
    {
        //talker = GetComponent<TOMTalk>(); 
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger Spike");
             talker.Talk("Be careful");
            spikeDoorAnimator.SetTrigger("SpikeOpen");

            
        }
    }
}
