using UnityEngine;

public class DogMoveState : EnemyMoveState
{
    public DogMoveState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject, GameObject followTarget, Rigidbody2D rgb, LayerMask layer, float speed) : base(enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed)
    {
        _attackPos = enemyStateController.hyenaAttackPos;
        _speed = speed;
    }

    private Transform _attackPos;
    private Transform _currentTransform;
    private float _speed;
    private float _timer;
    public override void OnEnter()
    {
        base.OnEnter();
        CanMove = true;
        IsMoving = true;
        _currentTransform = EnemyGameobject.transform;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Vector3 currentPos = _currentTransform.position;
        Vector3 targetPos=_attackPos.position;
        Direction = (targetPos-currentPos).normalized;
        if (Vector3.Distance(currentPos, targetPos) <= 0.005f)
        {
            State.ChangeState(EnemyStateController.EnemyAttackState);
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        float speed = _speed * Time.fixedDeltaTime;
        if (CanMove && IsMoving)
        {
            Rigidbody2D.MovePosition(Rigidbody2D.transform.position + Direction*speed);
        }
    }
}
