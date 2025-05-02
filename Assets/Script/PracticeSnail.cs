using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeSnail : MonoBehaviour
{

   
    void OnTriggerEnter(Collider other){
        //Debug.Log("" + other.gameObject);
        if (other.CompareTag("Player")){
            Debug.Log("PLayer alert");
        }
    }
}
