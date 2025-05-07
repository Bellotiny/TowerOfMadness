using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject destroyVersion;
    //public GameObject optionalObject;  
  
   
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Sword"))
        {
            Instantiate(destroyVersion, transform.position,transform.rotation);
       
            Destroy(gameObject);
        }
    }
}
