using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
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
    public bool canAttack = false;
    public bool isHit = false;
    public MobEnemyController[] mobEnemies;
    //private AudioSource audioSource;
    protected virtual void Start()
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
    
    protected virtual void Update()
    {  
        // tells your in what state
         currentState = StateMachine.GetCurrentStateType();
         // makes the state machine work every frame
         StateMachine.Update();
         // send agent speed to animator for walking anim purpose
         animator.SetFloat("speed", Agent.velocity.magnitude);
         // Making you chase

        var foundMobs = FindObjectsOfType<MobEnemyController>();
        if(foundMobs.Length == 0){
            canAttack = true;
        }
           
            //Debug.Log(foundMobs + " : " + foundMobs.Length);

        if (CanSeePlayer() && canAttack && (currentState != StateType.Chase || currentState != StateType.Attack)){
            Debug.Log("Chasing Player...");
            StateMachine.TransitionToState(StateType.Chase);
            return;
        }
    }
    public bool CanSeePlayer(){
        float distanceToPlayer = Vector3.Distance(transform.position,
        Player.position);

        if (distanceToPlayer <= SightRange)
        {
            return true;
        }
        return false;
    }

    public bool IsPlayerInAttackRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position,
        Player.position);
        return distanceToPlayer <= AttackRange;
    }
    
  
    public virtual void GotHit()
    {
        if (isHit) return;

        StartCoroutine(HandleHit());
    }
    private IEnumerator HandleHit()
    {
        isHit = true;
        hitParticles.Play();
        animator.SetTrigger("GotHit");
        health.TakeDamage(20);
        Agent.isStopped = true;

        yield return new WaitForSeconds(0.5f);

        Agent.isStopped = false;
        isHit = false;
    }

}
