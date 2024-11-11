using UnityEngine;

public class DogAttackState : EnemyAttackState
{
    public DogAttackState(EnemyStateMachineMain enemyStateController, EnemyState state, GameObject enemyGameobject,
        GameObject followTarget ,Rigidbody2D rgb, LayerMask layer, Animator animator, float speed) :
        base(enemyStateController, state, enemyGameobject, followTarget, rgb, layer, speed)
    {
        _animator = animator;
        _attackPos = enemyStateController.hyenaAttackPos;
    }
    private readonly Animator _animator;
    private readonly Transform _attackPos;
    private Transform _currentTransform;
    private Vector3 _currentPos;
    private float _timer;
    private float _attackAnimationDuration;
    
    public override void OnEnter()
    {
        base.OnEnter();
        _currentTransform = EnemyGameobject.transform;
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
        Vector3 currentPos = _currentTransform.position;
        Vector3 targetPos=_attackPos.position;
        Direction = (targetPos-currentPos).normalized;
        if (Vector3.Distance(currentPos, targetPos) >= 0.15f && _timer>=_attackAnimationDuration)
        {
            State.ChangeState(EnemyStateController.EnemyMoveState);
        }
      else if (Vector3.Distance(currentPos, targetPos) >= 0.15f && _timer<=_attackAnimationDuration)
      {
           State.ChangeState(EnemyStateController.EnemyIdleState);
      }
    }
}
