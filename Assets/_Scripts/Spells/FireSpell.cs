 using UnityEngine;

public class FireSpell : BaseSpell
{
    private Vector3 _direction;
    private bool _isFacingRight = false;
    private bool _isAnimationEnded;
    protected override void Start()
    {
        base.Start();
        _isAnimationEnded = false;
        if (PlayerPosition != null)
        {
            Vector2 playerPosition = PlayerPosition.position;
            Vector2 spellPosition = transform.position;
            _direction = (playerPosition - spellPosition).normalized;
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            RotateSpellTowardsPlayer();
        }
    }
    protected override void FixedUpdate()
    {
        base.Update();
        CastSpell(_direction,speed);
    }   
    public override void CastSpell(Vector2 direction, float speed)
    {
        if (_isAnimationEnded)
        {
            float adjustSpeed = speed * Time.fixedDeltaTime;
            Rgb.linearVelocity = direction * adjustSpeed;
            DestroySpell();
        }
    }
    public void StopAnimation()
    {
        Animator.speed = 0f;
        _isAnimationEnded = true;
    }
}