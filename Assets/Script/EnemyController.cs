using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private EnemyMovement movement;
    private EnemyHealth health;
    private ParticleSystem hitParticles;
    //private AudioSource audioSource;
    void Start()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
        movement = GetComponent<EnemyMovement>();
        hitParticles = GetComponent<ParticleSystem>();
        //audioSource = GetComponent<AudioSource>();
    }
    public void GotHit()
    {
        hitParticles.Play();
        health.TakeDamage(35);
        //audioSource.Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
