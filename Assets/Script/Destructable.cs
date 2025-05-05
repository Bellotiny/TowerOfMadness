using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject destroyVersion;
    //public GameObject optionalObject;  
  
   
    void OnMouseDown(){
        Instantiate(destroyVersion, transform.position,transform.rotation);
       
        Destroy(gameObject);

    }
}
