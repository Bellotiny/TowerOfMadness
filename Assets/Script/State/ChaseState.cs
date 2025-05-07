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
        enemyController.Agent.destination = enemyController.Player.position;
    }

    public void Exit()
    {
    // No cleanup
    }

}
