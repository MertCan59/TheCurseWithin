using UnityEngine;

public class CursedCharacterController : PlayerAttackController
{
    protected override ICharacterHit CreateCharacterHit()
    {
        return new CursedFormHit();
    }

    protected override void ApplyDamage(IDamageable damageable)
    {
        damageable.GetDamage(62);
    }
}
