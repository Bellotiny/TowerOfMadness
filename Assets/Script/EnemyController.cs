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
    public int damageTaken { get; protected set; } = 20;
    public bool isMob = false;
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
        Debug.Log($"{gameObject.name} - CurrentState: {currentState}");
        Debug.Log($"{gameObject.name} - CanSeePlayer: {CanSeePlayer()}");
        Debug.Log($"{gameObject.name} - canAttack: {canAttack}");

        if (!isMob && MobEnemyController.activeMobs.Count > 0)
        {
            animator.SetFloat("speed", 0f);
            return;
        }
        canAttack = true;
        currentState = StateMachine.GetCurrentStateType();
        StateMachine.Update();
        animator.SetFloat("speed", Agent.velocity.magnitude);

        // var foundMobs = FindObjectsOfType<MobEnemyController>();
        // if(foundMobs.Length == 0){
        //     canAttack = true;
        // }

        //Debug.Log(foundMobs + " : " + foundMobs.Length);

        // if (CanSeePlayer() && canAttack && (currentState != StateType.Chase || currentState != StateType.Attack)){
        //     Debug.Log("Chasing Player...");
        //     StateMachine.TransitionToState(StateType.Chase);
        //     return;
        // }
        if (CanSeePlayer() && canAttack && currentState != StateType.Chase && currentState != StateType.Attack)
        {
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
    protected IEnumerator HandleHit()
    {
        isHit = true;
        hitParticles.Play();
        animator.SetTrigger("GotHit");
        health.TakeDamage(damageTaken);
        Agent.isStopped = true;

        yield return new WaitForSeconds(0.5f);

        Agent.isStopped = false;
        isHit = false;
    }

}
