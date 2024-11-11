using JetBrains.Annotations;
using UnityEngine;

public abstract class EnemyDamageObserver : MonoBehaviour,IEnemyDamageObserver
{
    protected float DamageAmount;
    protected float CurrentHp;
    [SerializeField] protected float hp;

    protected virtual void Awake()
    {
        CurrentHp = hp;
    }
    protected virtual void Start()
    {}
    private void OnEnable()
    {
        GetComponent<EnemyTakeDamage>().AddEnemyObserver(this);
    }
    private void OnDisable()
    {
        GetComponent<EnemyTakeDamage>().RemoveEnemyObserver(this);
    }
    public abstract void OnDamageTaken();
}
