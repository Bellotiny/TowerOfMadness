using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackState : IState
{
    private EnemyController enemyController;
    public StateType Type => StateType.Attack;

    public AttackState(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public void Enter(){
        Debug.Log("Attacking Player...");
        enemyController.animator.SetTrigger("DoAttack");
        enemyController.Agent.isStopped = true;
    }

    public void Execute()
    {
        // Check if the player is within attack range
        if (Vector3.Distance(enemyController.transform.position,
            enemyController.Player.position) > enemyController.AttackRange)
        {
            // If the player moves away, transition back to ChaseState
            enemyController.StateMachine.TransitionToState(StateType.Chase);
            return;
        }
    }
    public void Exit()
    {

        enemyController.Agent.isStopped = false; // Resume the AI agent movement
    }
}
