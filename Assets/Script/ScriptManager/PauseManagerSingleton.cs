using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManagerSingleton : MonoBehaviour
{
    public static PauseManagerSingleton Instance { get; private set;}
    // Start is called before the first frame update
    void Awake(){
         if (Instance == null){
            DontDestroyOnLoad(gameObject);
             Instance = this;
        }
        else{
             Destroy(gameObject);
        }
     }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
