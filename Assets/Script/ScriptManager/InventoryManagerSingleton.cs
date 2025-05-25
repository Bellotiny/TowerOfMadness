using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagerSingleton : MonoBehaviour
{
     public static InventoryManagerSingleton Instance { get; private set;}
     void Awake(){
         if (Instance == null){
            DontDestroyOnLoad(gameObject);
             Instance = this;
        }
        else{
             Destroy(gameObject);
        }
     }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
