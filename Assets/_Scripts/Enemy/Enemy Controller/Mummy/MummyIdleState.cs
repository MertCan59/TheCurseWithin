using UnityEngine;
public class MummyIdleState: EnemyIdleState,IEnemyState
{
    public MummyIdleState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject, GameObject followTarget, Rigidbody2D rgb, LayerMask layer, float speed) : base(enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed)
    {}
    public override void OnEnter()
    {
        base.OnEnter();
        _timer = 0f;
    }
    private float _timer;
    public override void OnUpdate()
    {
        base.OnUpdate();
        Vector3 playerPos = FollowTarget.transform.position;
        Vector3 currentPos=EnemyGameobject.transform.position;
        float closestDistance = 2.5f;
        Vector3 offset = playerPos - currentPos;
        float sqrLen = offset.sqrMagnitude;

        if (sqrLen <= closestDistance)
        {
            _timer += Time.deltaTime;
            if (_timer >= 0.75f)
            {
                State.ChangeState(EnemyStateController.EnemyAttackState);
            }
        }
        else if(sqrLen >= closestDistance)
        {
            State.ChangeState(EnemyStateController.EnemyMoveState);
        }
    }
    public Vector3 RotateDirection()
    {
        Vector3 playerPos = FollowTarget.transform.position;
        Vector3 currentPos = EnemyGameobject.transform.position;
        return (playerPos - currentPos).normalized;
    }
}
