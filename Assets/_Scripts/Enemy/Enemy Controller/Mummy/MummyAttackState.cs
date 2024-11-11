using UnityEngine;
public class MummyAttackState : EnemyAttackState
{
    public MummyAttackState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject,
        GameObject followTarget, Rigidbody2D rgb, LayerMask layer, Animator animator, float speed) : base(
        enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed)
    {
        _animator = animator;
    }
    private Transform _targetTransform;
    private Transform _currentTransform;
    private Animator _animator; 
    private Vector3 _currentPos;
    private float _closestDist;
    private float _timer;
    private float _attackAnimationDuration;
    
    public override void OnEnter()
    {
        base.OnEnter();
        _targetTransform = FollowTarget.transform;
        _currentTransform = EnemyGameobject.transform;
        _currentPos = _currentTransform.position;
        _closestDist = 2.5f;
        _timer = 0f;
        var currentClipInfo = _animator.GetCurrentAnimatorClipInfo(0);
        if (currentClipInfo.Length > 0)
        {
            _attackAnimationDuration = currentClipInfo[0].clip.length;
        }
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        _timer += Time.deltaTime;
        Vector3 targetPos = _targetTransform.position;
        Vector3 offset = targetPos-_currentPos;
        float sqrtLen = offset.sqrMagnitude;
        Direction = (targetPos-_currentPos).normalized;
        if (sqrtLen >= _closestDist && _timer >= _attackAnimationDuration+0.25f)
        {
            State.ChangeState(EnemyStateController.EnemyMoveState);
        }
        else if (sqrtLen < _closestDist && _timer >= _attackAnimationDuration+0.25f) 
        {
            State.ChangeState(EnemyStateController.EnemyIdleState);
        }
    }
}
