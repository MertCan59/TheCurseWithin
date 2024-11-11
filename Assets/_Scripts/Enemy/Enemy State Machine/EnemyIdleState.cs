using System;
using UnityEngine;

public class EnemyIdleState : EnemyStateMachine,IEnemyState
{
    public EnemyIdleState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject, GameObject followTarget, Rigidbody2D rgb, LayerMask layer, float speed) : base(enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed)
    {}
    public event Action OnIdleAction;

    public override void OnEnter()
    {
        base.OnEnter();
        CanMove = false;
        IsMoving = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        OnIdleAction?.Invoke();
    }
    public Vector3 RotateDirection()
    {
        Vector3 playerPos = FollowTarget.transform.position;
        Vector3 currentPos = EnemyGameobject.transform.position;
        return (playerPos - currentPos).normalized;
    }
}
