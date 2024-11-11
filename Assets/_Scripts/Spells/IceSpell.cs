using UnityEngine;

public class IceSpell : BaseSpell
{
    private Vector3 _direction;
    private float testSpeed = 150f;
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
        base.FixedUpdate();
     
        CastSpell(_direction,speed/2);
    }

    public override void CastSpell(Vector2 direction, float speed)
    {
        if (_isAnimationEnded)
        {
            float adjustSpeed = speed * Time.fixedDeltaTime;
            Rgb.MovePosition(Rgb.transform.position+(Vector3)direction * adjustSpeed);
            DestroySpell();
        }
    }
    public void StopAnimation()
    {
        Animator.speed = 0f;
        _isAnimationEnded = true;
    }
}
