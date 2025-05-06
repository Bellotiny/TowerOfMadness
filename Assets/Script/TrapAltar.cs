using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAltar : MonoBehaviour
{
    public int durability = 100;
    public GameObject energyBallPrefab;
    public float respawnDelay = 1f;
    [SerializeField] private float spawnHeightInInches = 2.5f;
    public bool playerInRoom = false;
    private GameObject currentEnergyBall;
    private bool isDestroyed = false;
    private ParticleSystem destructionEffect;
    private bool spawnScheduled = false;
    void Start()
    {
        destructionEffect = GetComponent<ParticleSystem>();
    }
    void OnCollisionEnter(Collider other){
        if (isDestroyed) return;

        if (other.CompareTag("Sword"))
        {
            durability -= 50;
        }
        if (other.CompareTag("Arrow"))
        {
            durability -= 35;
        }
    }
    void SpawnEnergyBall()
    {
        if (energyBallPrefab && !isDestroyed && spawnScheduled)
        {
            float heightInUnits = spawnHeightInInches / 39.37f;
            Vector3 spawnPosition = transform.position + new Vector3(0, heightInUnits, 0);
            currentEnergyBall = Instantiate(energyBallPrefab, spawnPosition, Quaternion.identity);
            spawnScheduled = false;
        }
    }
    public void NotifyPlayerEnteredRoom()
    {
        if (!playerInRoom && !isDestroyed)
        {
            Debug.Log("Player entered the room.");
            playerInRoom = true;
            //Invoke(nameof(SpawnEnergyBall), respawnDelay);
        }
    }
    public void NotifyPlayerExitedRoom()
    {
        Debug.Log("Player left the room.");
        playerInRoom = false;
    }
    void Update()
    {
        if (!isDestroyed && playerInRoom && currentEnergyBall == null)
        {
            spawnScheduled = true;
            Invoke(nameof(SpawnEnergyBall), respawnDelay);
        }

        if (durability <= 0 && !isDestroyed)
        {
            DestroyAltar();
        }
    }

    void DestroyAltar()
    {
        isDestroyed = true;
        if (destructionEffect != null)
        {
            destructionEffect.Play();
        }
        Destroy(gameObject);
    }
}
