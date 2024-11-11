using System;
using UnityEngine;

public class EnemyMoveState : EnemyStateMachine,IEnemyState
{
    public EnemyMoveState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject, GameObject followTarget, Rigidbody2D rgb,
        LayerMask layer, float speed) 
        : base(enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed)
    {}
    public event Action OnMoveAction;
    public override void OnEnter()
    {
        base.OnEnter();
        IsMoving = true;
        CanMove = true;
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        if (IsMoving && CanMove)
        {
            OnMoveAction?.Invoke();
        }
    }
    protected void UpdateDirection(Vector2 newDirection)
    {
        Direction = newDirection;
    }
    
    public Vector3 RotateDirection()
    {
        Vector3 playerPos = FollowTarget.transform.position;
        Vector3 currentPos = EnemyGameobject.transform.position;
        return (playerPos - currentPos).normalized;
    }
}
