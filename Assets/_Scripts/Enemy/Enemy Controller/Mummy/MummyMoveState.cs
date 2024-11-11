using UnityEngine;

public class MummyMoveState : EnemyMoveState
{
    public MummyMoveState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject,
        GameObject followTarget, Rigidbody2D rgb, LayerMask layer, float speed) : base(enemyStateController, state,
        enemyGameobject, followTarget, rgb, layer, speed)
    {
        _speed = speed;
    }
    
    private Transform _targetTransform;
    private Transform _currentTransform;
    private float _speed;
    private float _timer;
    private float _closestDist;
    public override void OnEnter()
    {
        base.OnEnter();
        _timer = 0f;
        CanMove = true;
        IsMoving = true;
        _targetTransform = FollowTarget.transform;
        _currentTransform = EnemyGameobject.transform;
        _closestDist = 2.5f;
    }
    
    public override void OnUpdate()
    {
        base.OnUpdate();
        _timer += Time.deltaTime;
        Vector3 currentPos = _currentTransform.position;
        Vector3 targetPos = _targetTransform.position;
        Vector3 offset = targetPos-currentPos;
        float sqrtLen = offset.sqrMagnitude;
        Direction = (targetPos-currentPos).normalized;

        if (sqrtLen <= _closestDist && _timer > 1.25f)
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
