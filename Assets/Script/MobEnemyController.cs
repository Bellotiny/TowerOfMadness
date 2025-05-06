using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobEnemyController : EnemyController
{
    public Animator animator;
    private EnemyMovement movement;
    private EnemyHealth health;
    private ParticleSystem hitParticles;
    public StateMachine StateMachine { get; private set; }
    public NavMeshAgent Agent { get; private set; }
    public Transform[] Waypoints;
    public Transform Player;
    public float SightRange = 10f;
    public float AttackRange = 2f;
    public LayerMask PlayerLayer;
    public StateType currentState;

    //private AudioSource audioSource;
    void Start()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
        movement = GetComponent<EnemyMovement>();
        hitParticles = GetComponent<ParticleSystem>();
        Agent = GetComponent<NavMeshAgent>();
        StateMachine = new StateMachine();
        StateMachine.AddState(new IdleState(this));
        StateMachine.AddState(new ChaseState(this));
        StateMachine.AddState(new AttackState(this));
        StateMachine.TransitionToState(StateType.Idle);
        //audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {  
        // tells your in what state
         currentState = StateMachine.GetCurrentStateType();
         // makes the state machine work every frame
         StateMachine.Update();
         // send agent speed to animator for walking anim purpose
         animator.SetFloat("speed", Agent.velocity.magnitude);
         // Making you chase
        if (CanSeePlayer() && (currentState != StateType.Chase || currentState != StateType.Attack)){
            StateMachine.TransitionToState(StateType.Chase);
            return;
        }
    }
    public void GotHit()
    {
        hitParticles.Play();
        health.TakeDamage(35);
        //audioSource.Play();
    }

   
}
