using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerAttackController : MonoBehaviour
{
    [SerializeField] protected Collider2D hitboxCollider;
    [SerializeField] protected UnityEvent onHitEvent;
    [SerializeField] protected PlayerDataSO playerData;
    private ICharacterHit _characterHit;
    protected abstract ICharacterHit CreateCharacterHit();
    protected abstract void ApplyDamage(IDamageable damageable);
    protected virtual void Start()
    {
        _characterHit = CreateCharacterHit();
    }
    protected virtual void Update()
    { } 
    protected virtual void EnableHitCollider()
    {
        hitboxCollider.enabled = true;
    }

    protected virtual void DisableHitCollider()
    {
        hitboxCollider.enabled = false;
    }
    protected void TriggerHitEffect()
    {
        _characterHit?.OnHitEvent();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        ITakeDamage takeDamage = other.GetComponent<ITakeDamage>();
        if (hitboxCollider.enabled)
        {
            if (damageable != null)
            {
                ApplyDamage(damageable);
                onHitEvent?.Invoke();
                takeDamage.TakeDamage();
            }
        }
    }
}
