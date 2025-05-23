using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollection : MonoBehaviour
{
     public int score = 50;

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if (tag == "Apple" || tag == "Watermelon" || tag == "Orb")
        {
            ScoreManager.Instance.AddScore(score);
            InventoryManager.Instance.AddItem(tag);
            //AudioParticleController.Instance.PlaySoundEffect("Pickup", other.transform.position);
            Destroy(other.gameObject);
            //Debug.Log("" + score);
            //GameManager.Instance.UpdatePickupText("+ 50");
        }
       
       

    }
}
