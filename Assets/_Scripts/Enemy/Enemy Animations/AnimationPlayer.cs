using UnityEngine;

public class AnimationPlayer : EnemyAnimationController
{
    public AnimationPlayer(Animator animator, EnemyStateMachine stateMachine,string idleHash,string runHash,string attackHash) : base(animator, stateMachine)
    {
        _idleHash = Animator.StringToHash(idleHash);
        _runHash =  Animator.StringToHash(runHash);
        _attackHash = Animator.StringToHash(attackHash);
    }
    
    private readonly int _idleHash;
    private readonly int _runHash;
    private readonly int _attackHash;

    protected override void PlayIdleAnimation()
    {
        if (!StateMachine.IsAttacking && !StateMachine.CanMove)
        {
            Animator.Play(_idleHash);
        }
    }

    protected override void PlayRunAnimation()
    {
        if (StateMachine.CanMove && !StateMachine.IsAttacking)
        {
            Animator.Play(_runHash);
        }
    }
    protected override void PlayAttackAnimation()
    {
        if(StateMachine.IsAttacking)Animator.Play(_attackHash);
    }
}
