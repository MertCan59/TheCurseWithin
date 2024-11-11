using UnityEngine;

public abstract class  EnemyAttackController : MonoBehaviour
{
    [SerializeField] protected Collider2D hitbox;
    protected abstract void ApplyDamage(IDamageable damageable);
    protected virtual void Start()
    { }
    protected virtual void Update()
    { }
    public void EnableHitCollider()
    {
        hitbox.enabled = true;
        hitbox.isTrigger = true;
    }

    public void DisableHitCollider()
    {
        hitbox.enabled = false;
        hitbox.isTrigger = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        ITakeDamage takeDamage = other.GetComponent<ITakeDamage>();
        if (hitbox.isTrigger)
        {
            if (damageable != null && other.gameObject.CompareTag("Player") && PlayerDamage.CanReceiveDamage)
            {
                ApplyDamage(damageable);
                takeDamage.TakeDamage();
            }
        }
    }
}