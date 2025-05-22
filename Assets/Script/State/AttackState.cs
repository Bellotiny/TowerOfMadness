using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackState : IState
{
    private EnemyController enemyController;
    public StateType Type => StateType.Attack;
    private float attackCooldown = 1.5f;
    private float lastAttackTime = -Mathf.Infinity;

    public AttackState(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public void Enter(){
        Debug.Log("Attacking Player...");
        // enemyController.animator.SetTrigger("DoAttack");
        // if (Time.time - lastAttackTime >= attackCooldown)
        // {
        //     Debug.Log("Does Attack...");
        //     enemyController.animator.SetTrigger("DoAttack");
        //     lastAttackTime = Time.time;
        // }
        enemyController.Agent.isStopped = true;
    }

    public void Execute()
    {
        if (enemyController.isHit) return;

        if (!enemyController.IsPlayerInAttackRange())
        {
            enemyController.StateMachine.TransitionToState(StateType.Chase);
            return;
        }

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Debug.Log("Does Attack...");
            //enemyController.animator.ResetTrigger("DoAttack");
            enemyController.animator.SetTrigger("DoAttack");
            lastAttackTime = Time.time;
        }
    }
    public void Exit()
    {

        enemyController.Agent.isStopped = false;
    }
}
