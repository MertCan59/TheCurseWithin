using UnityEngine;
using System.Collections;

public class WarriorAnimatorController : AnimationController
{
   public WarriorAnimatorController(Animator animator) : base(animator)
    {
        
        _idleHash = Animator.StringToHash("Warrior_Idle");
        _runHash = Animator.StringToHash("Warrior_Run");
        _attackHash1 = Animator.StringToHash("Warrior_Attack1");
        _attackHash2 = Animator.StringToHash("Warrior_Attack2");
        NormalizeTime = 1.1f;
    }
    private const float ComboWindow = 0.5f;
    private readonly int _idleHash;
    private readonly int _runHash;
    private readonly int _attackHash1;
    private readonly int _attackHash2;
    private bool _canCombo;
    protected override void PlayIdleAnimation()
    {
        if (!IsAttacking) Animator.Play(_idleHash);
    }

    protected override void PlayRunAnimation()
    {
        if (!IsAttacking && MovementController.CanMove) Animator.Play(_runHash);
    }

    protected override void PlayAttackAnimation()
    {
        if (!IsAttacking)
        {
            IsAttacking = true;
            Animator.Play(_attackHash1);
            CoroutineController.Instance.StartCustomCoroutine(StartComboWindow());
            CoroutineController.Instance.StartCustomCoroutine(ResetIsAttackingAfterAnimation(NormalizeTime));
        }
        else if (IsAttacking && _canCombo)
        {
            Animator.Play(_attackHash2);
            _canCombo = false;
        }
    }
    private IEnumerator StartComboWindow()
    {
        _canCombo = false;
        float animationLength = Animator.GetCurrentAnimatorStateInfo(0).length ;
        yield return new WaitForSeconds(animationLength);
        _canCombo = true;
        yield return new WaitForSeconds(ComboWindow);
        _canCombo = false;
    }
}
