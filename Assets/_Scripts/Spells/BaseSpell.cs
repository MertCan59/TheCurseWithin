using System;
using UnityEngine;

public abstract class BaseSpell : MonoBehaviour,ISpell
{
    protected Rigidbody2D Rgb;
    protected Transform PlayerPosition;
    [SerializeField] protected float duration;
    [SerializeField] protected float rotationSpeed;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    protected Animator Animator;

    protected virtual void Awake()
    {
        Rgb = GetComponent<Rigidbody2D>();
        PlayerPosition = GameObject.FindWithTag("Player").transform;
        Animator = GetComponent<Animator>();
    }

    protected virtual void Start()
    {}

    protected virtual void Update()
    {}
    protected virtual void FixedUpdate()
    {}
    public abstract void CastSpell(Vector2 direction, float speed);
    
    protected void RotateSpellTowardsPlayer()
    {
        if (PlayerPosition != null)
        {
            Vector2 playerPosition = PlayerPosition.position;
            Vector2 spellPosition = transform.position;
            Vector2 directionToPlayer = (playerPosition - spellPosition).normalized;

            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    protected void DestroySpell()
    {
        Destroy(gameObject,duration);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        ITakeDamage takeDamage = other.GetComponent<ITakeDamage>();
        if (damageable != null && other.gameObject.CompareTag("Player"))
        {
            takeDamage.TakeDamage();
            damageable.GetDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
