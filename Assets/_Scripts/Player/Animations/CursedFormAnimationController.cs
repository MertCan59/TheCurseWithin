using UnityEngine;

public class CursedFormAnimationController : AnimationController
{
    public CursedFormAnimationController(Animator animator) : base(animator)
    {
        _idleHash = Animator.StringToHash("CursedFormIdle");
        _runHash = Animator.StringToHash("CursedFormRun");
        _attackHash = Animator.StringToHash("CursedFormAttack");
        NormalizeTime = 1.0f;
    }
    private readonly int _idleHash;
    private readonly int _runHash;
    private readonly int _attackHash;
    protected override void PlayIdleAnimation()
    {
        if (!IsAttacking) Animator.Play(_idleHash);
    }

    protected override void PlayRunAnimation()
    {
        if (!IsAttacking) Animator.Play(_runHash);
    }

    protected override void PlayAttackAnimation()
    {
        IsAttacking = true;
        Animator.Play(_attackHash);
        CoroutineController.Instance.StartCustomCoroutine(ResetIsAttackingAfterAnimation(NormalizeTime));
    }
}
