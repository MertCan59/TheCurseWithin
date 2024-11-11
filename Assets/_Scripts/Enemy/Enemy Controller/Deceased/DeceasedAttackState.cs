using System.Collections;
using UnityEngine;

public class DeceasedAttackState: EnemyAttackState,IEnemyState
{
    public DeceasedAttackState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject,
        GameObject followTarget, Rigidbody2D rgb, LayerMask layer, Animator animator, float speed) : base(
        enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed)
    {
        _animator = animator;
    }

    private Animator _animator;
    private bool _coroutineRunning;

    public override void OnEnter()
    {
        base.OnEnter();
        CanMove = false;
        IsAttacking = true;
        _coroutineRunning = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (IsAttacking && !_coroutineRunning)
        {
            CoroutineController.Instance.StartCustomCoroutine(StopAttacking());
            _coroutineRunning = true;
        }
        if (!IsAttacking)
        {
            _coroutineRunning = false;
            State.ChangeState(EnemyStateController.EnemyIdleState);
        }
    }
    public Vector3 RotateDirection()
    {
        Vector3 playerPos = FollowTarget.transform.position;
        Vector3 currentPos = EnemyGameobject.transform.position;
        return (playerPos - currentPos).normalized;
    }

    private IEnumerator StopAttacking()
    {
        if (IsAttacking)
        {
            float animationTime = _animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationTime);
            IsAttacking = false;
        }
        yield return null;
        _coroutineRunning = false;
    }
}
