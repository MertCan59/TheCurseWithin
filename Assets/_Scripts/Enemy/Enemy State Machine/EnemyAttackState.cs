using System;
using UnityEngine;

public class EnemyAttackState : EnemyStateMachine
{
    public EnemyAttackState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject, GameObject followTarget, Rigidbody2D rgb, LayerMask layer, float speed) : base(enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed)
    {}

    public Action OnAttackState;
    public override void OnEnter()
    {
        base.OnEnter();
        IsAttacking = true;
    }
    
    public override void OnUpdate()
    {
        base.OnUpdate();
        OnAttackState?.Invoke();
    }
    
    public void AttackStop()
    {
        IsAttacking = false;
    }
}
