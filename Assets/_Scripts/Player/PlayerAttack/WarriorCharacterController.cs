using UnityEngine;

public class WarriorCharacterController : PlayerAttackController,IHandleAnimationEvent
{
    private Vector2 _offset;
    private const float DamageMultiplier=2.5f;
    protected override ICharacterHit CreateCharacterHit()
    {
        return new WarriorFormHit();
    }
    protected override void ApplyDamage(IDamageable damageable)
    {
        int randomValue = Random.Range(0, 100);
        int damageInterval = Random.Range(1, 10);
        float damageAmount = playerData.attackPower;
        if (randomValue == 50)
        {
            damageable.GetExtraDamage((damageAmount+damageInterval)*DamageMultiplier);
        }
        else
        {
            damageable.GetDamage(damageAmount+damageInterval);
        }
    }
    public void SetAnim1HitboxOffset()
    {
        _offset = new Vector2(1.18f,0f); ;
        hitboxCollider.offset = _offset;
    }
    public void SetAnim2HitboxOffset()
    {
        _offset = new Vector2(1.7f,0f); ;
        hitboxCollider.offset = _offset;
    }
    public void HandleAnimationEvent()
    {
       Debug.Log("To perform animation's unique behaviours ");
    }
}