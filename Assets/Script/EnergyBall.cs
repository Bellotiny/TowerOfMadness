using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public float waitTime = 3f;
    public float shootForce = 10f;
    public Material redMaterial;
    private Rigidbody rb;
    private Renderer rend;
    private bool hasShot = false;
    private Transform player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        player = GameObject.FindWithTag("Player").transform;
        rb.isKinematic = true;
        Invoke(nameof(ShootAtPlayer), waitTime);
    }
    void ShootAtPlayer()
    {
        if (player == null) return;

        hasShot = true;
        rend.material = redMaterial;
        rb.isKinematic = false;
        Vector3 direction = (player.position - transform.position).normalized;
        rb.AddForce(direction * shootForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(20);
            }
        }
        Debug.Log("Energyball destroyed");
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
}
