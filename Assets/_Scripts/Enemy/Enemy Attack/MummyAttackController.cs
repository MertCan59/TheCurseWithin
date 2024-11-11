using UnityEngine;

public class MummyAttackController : EnemyAttackController
{
    [SerializeField] private float attackPower;
    private const float DamageMultiplier=1.5f;

    protected override void ApplyDamage(IDamageable damageable)
    {
        int randomValue = Random.Range(0, 100);
        int damageInterval = Random.Range(1, 10);
        float damageAmount = attackPower;
        if (randomValue == 50)
        {
            damageable.GetExtraDamage((damageAmount+damageInterval)*DamageMultiplier);
        }
        else
        {
            damageable.GetDamage(damageAmount);
        }
    }
    
}
