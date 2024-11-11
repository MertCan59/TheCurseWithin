using UnityEngine;
using System.Collections;
public abstract class AnimationController
{
    protected readonly Animator Animator;
    protected bool IsAttacking;
    protected float NormalizeTime;
    protected AnimationController(Animator animator)
    {
        Animator = animator;
    }
    
    protected abstract void PlayIdleAnimation();
    protected abstract void PlayRunAnimation();
    protected abstract void PlayAttackAnimation();

    public void OnEnable()
    {
        MovementController.OnMovementStatusChanged += PlayRunAnimation;
        MovementController.OnMovementStop += PlayIdleAnimation;
        InputController.AttackEvent += PlayAttackAnimation;
    }

    public void OnDisable()
    {
        MovementController.OnMovementStatusChanged -= PlayRunAnimation;
        MovementController.OnMovementStop -= PlayIdleAnimation;
        InputController.AttackEvent -= PlayAttackAnimation;
    }

    protected IEnumerator ResetIsAttackingAfterAnimation(float normalizeTime)
    {
        yield return new WaitForEndOfFrame();
        MovementController.CanMove = false;
        while (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < normalizeTime)
        {
            yield return null;
        }
        IsAttacking = false;
        MovementController.CanMove = true;

        if (MovementController.Direction.magnitude > 0.1f)
        {
            PlayRunAnimation();
        }
        else
        {
            PlayIdleAnimation();
        }
    }
}