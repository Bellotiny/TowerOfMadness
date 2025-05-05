using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRoom : MonoBehaviour
{
    public TrapAltar trapAltar;

    void Start(){
        //trapAltar = GetComponent<TrapAltar>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the room trigger zone.");
            trapAltar.NotifyPlayerEnteredRoom();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left the room trigger zone.");
            //trapAltar.NotifyPlayerExitedRoom();
        }
    }
}
