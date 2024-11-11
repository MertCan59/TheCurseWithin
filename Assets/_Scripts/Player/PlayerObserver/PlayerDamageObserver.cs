using UnityEngine;
using UnityEngine.Serialization;

public abstract class PlayerDamageObserver : MonoBehaviour,IPlayerDamageObserver
{
    protected float DamageAmount;
    [HideInInspector] public bool isAlive;
    [HideInInspector] public float CurrentHp;
    public float hp;

    protected virtual void Awake()
    {
        CurrentHp = hp;
        isAlive = true;
    }
    protected virtual void Start()
    {}
    protected virtual void OnEnable()
    {
        GetComponent<PlayerTakeDamage>().AddEnemyObserver(this);
    }
    protected virtual void OnDisable()
    {
        GetComponent<PlayerTakeDamage>().RemoveEnemyObserver(this);
    }
    public abstract void OnDamageTaken();
}
