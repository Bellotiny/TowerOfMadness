using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobEnemyController : EnemyController
{
    private EnemyHealth health;
    private ParticleSystem hitParticles;
    //private AudioSource audioSource;
    void Start()
    {
        base.Start();
        health = GetComponent<EnemyHealth>();
        hitParticles = GetComponent<ParticleSystem>();
        //audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {  
        base.Update();
    }
    public override void GotHit()
    {
        hitParticles.Play();
        health.TakeDamage(35);
        //audioSource.Play();
    }

   
}
