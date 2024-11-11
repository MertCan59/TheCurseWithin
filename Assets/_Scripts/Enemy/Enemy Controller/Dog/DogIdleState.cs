using UnityEngine;

public class DogIdleState : EnemyIdleState
{
    public DogIdleState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject, GameObject followTarget, Rigidbody2D rgb, LayerMask layer, float speed) :
        base(enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed)
    {
        _attackPos = enemyStateController.hyenaAttackPos;
    }
    private readonly Transform _attackPos;
    public override void OnEnter()
    {
        base.OnEnter();;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Vector3 pos=EnemyGameobject.transform.position;
        if (pos != _attackPos.position)
        {
            State.ChangeState(EnemyStateController.EnemyMoveState);
        }
        else
        {
            State.ChangeState(EnemyStateController.EnemyAttackState);
        }
    }
}
