using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechWarning : MonoBehaviour
{
     public TOMTalk talker;


      void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WallWarning"))
        {
            Debug.Log("wall warning");
            talker.Talk("Path is blocked");

             StartCoroutine(DelayedTalk("Find the key on these jar", 10f));
            
        }
    }
    IEnumerator DelayedTalk(string newMessage, float delay)
    {
        yield return new WaitForSeconds(delay);
        talker.Talk(newMessage);
    }
}
