using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollection : MonoBehaviour
{
     public int score = 50;

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if (tag == "Apple" || tag == "Watermelon")
        {
            //Debug.Log(tag);
            ScoreManager.Instance.AddScore(score);

            //AudioParticleController.Instance.PlaySoundEffect("Pickup", other.transform.position);

            //Debug.Log("" + score);
            //GameManager.Instance.UpdatePickupText("+ 50");
            InventoryManager.Instance.AddItem(tag);
            Destroy(other.gameObject);
        }

        if (tag == "Orb")
        {
            ScoreManager.Instance.AddOrb();
            InventoryManager.Instance.AddItem(tag);
            Destroy(other.gameObject);
        }

        else if (tag == "DoorKey")
        {
            Destroy(other.gameObject);
            WallController wall = FindObjectOfType<WallController>();

            if (wall != null)
            {
                wall.OpenAndCloseWall(2f); // Pass the wait time before the wall closes again
            }


        }

        
       
       

    }
}
