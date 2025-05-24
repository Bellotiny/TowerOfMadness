using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRoom : MonoBehaviour
{
    private TrapAltar[] trapAltars;
    void Start()
    {
        trapAltars = GetComponentsInChildren<TrapAltar>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the room trigger zone.");

            foreach (var altar in trapAltars)
            {
                altar.NotifyPlayerEnteredRoom();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left the room trigger zone.");

            foreach (var altar in trapAltars)
            {
                altar.NotifyPlayerExitedRoom();
            }
        }
    }
}