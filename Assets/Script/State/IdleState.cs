using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
   private EnemyController enemyController;
   private float idleDuration = 2f;
   private float idleTimer;

   public StateType Type => StateType.Idle;

   public IdleState(EnemyController enemyController){
    this.enemyController = enemyController;
   }

   public void Enter(){
    idleTimer = 0f;
    //aiController.Animator.SetBool("isMoving", false);
   }

   public void Execute(){
    idleTimer += Time.deltaTime;
    
    // if(idleTimer >= idleDuration){
    //     enemyController.StateMachine.TransitionToState(StateType.Patrol);
    // }
   }

   public void Exit(){
    
    //Cleanup
   }

   
}

