using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public float waitTime = 3f;
    public float shootForce = 10f;
    public Material redMaterial;
    private ParticleSystem burstEffect;
    private Rigidbody rb;
    private Renderer rend;
    private bool hasShot = false;
    private Transform player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        burstEffect = GetComponent<ParticleSystem>();
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
        rb.useGravity = false;
        rb.AddForce(direction * shootForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                Debug.Log("Player was hit!!!!");
                health.TakeDamage(20);
            }
        }
        if(burstEffect != null){
            // Detach, play, and destroy the effect separately
            burstEffect.transform.SetParent(null);
            burstEffect.Play();
            Destroy(burstEffect.gameObject, burstEffect.main.duration);
        }
        Debug.Log("Energyball destroyed");
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
}
