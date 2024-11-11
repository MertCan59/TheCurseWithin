using UnityEngine;

public abstract class EnemyAnimationController
{
   protected EnemyAnimationController(Animator animator,EnemyStateMachine stateMachine)
    {
        Animator = animator;
        StateMachine = stateMachine;
    }
   
    protected readonly Animator Animator;
    protected EnemyStateMachine StateMachine;
    
    protected abstract void PlayIdleAnimation();
    protected abstract void PlayRunAnimation();
    protected abstract void PlayAttackAnimation();

    public void OnEnable()
    {
        if (StateMachine is EnemyIdleState idleState) 
            idleState.OnIdleAction += PlayIdleAnimation;
        if (StateMachine is EnemyMoveState moveState) 
            moveState.OnMoveAction += PlayRunAnimation;
        if (StateMachine is EnemyAttackState enemyAttackState)
            enemyAttackState.OnAttackState += PlayAttackAnimation;
    }
    public void OnDisable()
    {
        if (StateMachine is EnemyIdleState idleState) 
            idleState.OnIdleAction -= PlayIdleAnimation;
        if (StateMachine is EnemyMoveState moveState) 
            moveState.OnMoveAction -= PlayRunAnimation;
        if (StateMachine is EnemyAttackState enemyAttackState)
            enemyAttackState.OnAttackState -= PlayAttackAnimation;
    }
}
