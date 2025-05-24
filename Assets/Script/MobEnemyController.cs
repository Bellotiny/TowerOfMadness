using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobEnemyController : EnemyController
{
    public static List<MobEnemyController> activeMobs = new List<MobEnemyController>();
    //private AudioSource audioSource;
    protected override void Start()
    {
        base.Start();
        isMob = true;
        damageTaken = 35;
        activeMobs.Add(this);
        //health = GetComponent<EnemyHealth>();
        //hitParticles = GetComponent<ParticleSystem>();
        //audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        base.Update();
        if (StateMachine == null)
        Debug.LogError("Mob's StateMachine is null!");
    }
    
    public override void GotHit()
    {
        //hitParticles.Play();
        if (isHit) return;
        StartCoroutine(HandleHit());
        //audioSource.Play();
    }

   
}
