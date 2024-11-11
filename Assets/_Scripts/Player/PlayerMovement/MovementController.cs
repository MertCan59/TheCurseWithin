using System;
using UnityEngine;

[Serializable]
public class MovementController:IMovable
{
    public static event Action OnMovementStatusChanged;
    public static event Action OnMovementStop;
    public static Vector2 Direction;
    public static bool CanMove=true;
    
    [SerializeField] private InputController inputController;
    [SerializeField] private MoveStruct moveStruct;
    
    private Vector2 _direction;
    private bool _isMoving; 
    private bool _isFacingRight=true;
    public void OnEnable()
    {
        inputController.MoveEvent += MovementDirection;
    }

    public void OnDisable()
    {
        inputController.MoveEvent -= MovementDirection;
    }
    public void MovementDirection(Vector2 dir)
    {
        _direction = new Vector2(dir.x, dir.y);
        _isMoving = _direction.magnitude > 0.1f;
        Direction.x = _direction.x;
        Direction.y = 0;
    }

    public Vector2 Move()
    {
        Vector2 newDir = _direction;
        float adjustSpeed = moveStruct.speed * Time.fixedDeltaTime;
        if(newDir==Vector2.zero)OnMovementStop?.Invoke(); 
        
        if (_isMoving & CanMove)
        {
            moveStruct.rigidbody2D.MovePosition(moveStruct.rigidbody2D.position+newDir*adjustSpeed);
            OnMovementStatusChanged?.Invoke(); 
            RotatePlayer();
        }
        return newDir;
    }

    private void RotatePlayer()
    {
        float movementDirection = _direction.x;
        Vector3 scale = moveStruct.transform.localScale;

        if ((movementDirection > 0 && !_isFacingRight)|| (movementDirection < 0 && _isFacingRight))
        {
            scale.x *=-1;
            _isFacingRight = !_isFacingRight;
        }
        moveStruct.transform.localScale = scale;
    }
}
[Serializable]
struct MoveStruct
{
    public Rigidbody2D rigidbody2D;
    public float speed;
    public Transform transform;
}