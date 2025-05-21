using UnityEngine;

public class ChaseState : IState
{
    private EnemyController enemyController;

    public StateType Type => StateType.Chase;

    public ChaseState(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public void Enter()
    {
        Debug.Log($"{enemyController.name} entered ChaseState.");
        enemyController.Agent.isStopped = false;
    }

    public void Execute()
    {
        // if (!enemyController.CanSeePlayer())
        // {
        //     enemyController.StateMachine.TransitionToState(StateType.Patrol);
        //     return;
        // }
        if (enemyController.isHit) return;

        if (enemyController.IsPlayerInAttackRange())
        {
            enemyController.StateMachine.TransitionToState(StateType.Attack);
            return;
        }
        if (!enemyController.Agent.isOnNavMesh)
        {
            Debug.LogWarning($"{enemyController.name}'s NavMeshAgent is NOT on a NavMesh!");
            return;
        }

        if (!enemyController.Agent.enabled)
        {
            Debug.LogWarning($"{enemyController.name}'s NavMeshAgent is DISABLED!");
            return;
        }
        enemyController.Agent.destination = enemyController.Player.position;
    }

    public void Exit()
    {
        Debug.Log($"{enemyController.name} exiting ChaseState.");
    }

}
